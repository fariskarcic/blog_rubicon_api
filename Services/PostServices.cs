using System;
using System.Collections.Generic;
using System.Linq;
using blog_rubicon_api.BogusFactories;
using blog_rubicon_api.Models;
using blog_rubicon_api.Transformers;
using blog_rubicon_api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace blog_rubicon_api.Services {
    public class PostServices : IPostServices {
        private readonly BlogContext _context;

        public PostServices (BlogContext context) {
            _context = context;
        }
        public PostViewModel AddPost (PostViewModel post) {

            Post newPost = PostTransformers.TransformIntoModel (post);

            var postMatch = _context.Posts.Where (m => m.Slug == newPost.Slug).Select (m => m.Slug).FirstOrDefault ();
            if (postMatch != null) {
                return null;
            }

            _context.Add (newPost);

            foreach (var tag in post.Tags) {
                var match = _context.Tags.Where (t => t.Text == tag).FirstOrDefault ();
                var tagId = 0;
                if (match == null) {
                    Tag newTag = new Tag () {
                    Text = tag
                    };
                    _context.Tags.Add (newTag);
                    _context.SaveChanges ();
                    tagId = newTag.Id;
                } else {
                    tagId = match.Id;
                }

                PostTag pt = new PostTag () {
                    PostId = newPost.Id,
                    TagId = tagId
                };
                _context.PostTags.Add (pt);
            }

            _context.SaveChanges ();
            var vm = PostTransformers.TransformIntoVM (newPost);
            return vm;
        }

        public PostsViewModel GetAllPosts (string tag = null) {

            var posts = new List<Post> ();

            if (tag == null) {
                posts = _context.Posts
                    .Include (m => m.Tags)
                    .ThenInclude (m => m.Tag)
                    .OrderByDescending (m => m.CreatedAt)
                    .ToList ();
            } else {
                posts = _context.PostTags
                    .Where (m => m.Tag.Text.Contains (tag))
                    .Select (m => m.Post)
                    .Include (m => m.Tags)
                    .ThenInclude (m => m.Tag)
                    .ToList ();
            }

            var blogPosts = new List<PostViewModel> ();

            foreach (var post in posts) {
                var p = PostTransformers.TransformIntoVM (post);
                blogPosts.Add (p);
            }

            PostsViewModel postsVM = new PostsViewModel () {
                BlogPosts = blogPosts,
                PostsCount = blogPosts.Count
            };

            return postsVM;
        }

        public PostViewModel GetPostBySlug (string slug) {
            var post = _context.Posts.Where (m => m.Slug == slug)
                .Include (m => m.Tags)
                .ThenInclude (m => m.Tag)
                .FirstOrDefault ();

            if (post != null) {
                PostViewModel vm = PostTransformers.TransformIntoVM (post);
                return vm;
            } else {
                return null;
            }
        }

        public bool RemovePost (string slug) {
            try {
                var post = _context.Posts.Where (m => m.Slug == slug)
                    .Include (m => m.Tags)
                    .FirstOrDefault ();

                _context.Posts.Remove (post);
                _context.SaveChanges ();

                return true;
            } catch {
                return false;
            }
        }

        public PostViewModel UpdatePost (string slug, UpdatePostViewModel post) {
            var p = _context.Posts.Where (m => m.Slug == slug)
                .Include (m => m.Tags)
                .ThenInclude (m => m.Tag)
                .FirstOrDefault ();

            if (post.Title != null) {
                var newSlug = FriendlyUrlHelper.GetFriendlyTitle (post.Title);

                var match = _context.Posts.Where (m => m.Slug == newSlug).Select (m => m.Slug).FirstOrDefault ();
                if (match != null) {
                    return null;
                }
                p.Slug = newSlug;
                p.Title = post.Title;
            }

            if (post.Description != null) {
                p.Description = post.Description;
            }

            if (post.Body != null) {
                p.Body = post.Body;
            }
            p.UpdatedAt = DateTime.Now;

            _context.SaveChanges ();

            var vm = PostTransformers.TransformIntoVM (p);

            return vm;
        }

    }
}