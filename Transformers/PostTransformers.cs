using System;
using System.Linq;
using blog_rubicon_api.Models;
using blog_rubicon_api.ViewModels;

namespace blog_rubicon_api.Transformers {
    public class PostTransformers {
        public static PostViewModel TransformIntoVM (Post post) {

            if (post != null) {
                string[] tags = post.Tags.Select (m => m.Tag.Text).ToArray ();

                PostViewModel vm = new PostViewModel () {
                    Slug = post.Slug,
                    Title = post.Title,
                    Description = post.Description,
                    Body = post.Body,
                    Tags = tags,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt
                };

                return vm;
            } else {
                return null;
            }
        }

        public static Post TransformIntoModel (PostViewModel vm) {

            var slug = FriendlyUrlHelper.GetFriendlyTitle (vm.Title);

            Post post = new Post () {
                Slug = slug,
                Title = vm.Title,
                Description = vm.Description,
                Body = vm.Body,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return post;
        }
    }
}