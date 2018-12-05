using System.Collections.Generic;
using blog_rubicon_api.Models;
using Bogus;

namespace blog_rubicon_api.BogusFactories {

    public class Factory {

        private readonly BlogContext _context;

        public Factory (BlogContext context) {
            _context = context;
        }

        public bool Create (int amount = 1) {

            using (var transaction = _context.Database.BeginTransaction ()) {
                var faker = new Faker ("en");

                var fakeTags = new Faker<Tag> ()
                    .RuleFor (t => t.Text, f => f.Lorem.Word ());

                var newTags = fakeTags.Generate (amount * 2);

                _context.Tags.AddRange (newTags);
                _context.SaveChanges ();

                var fakePosts = new Faker<Post> ()
                    .RuleFor (p => p.Title, f => f.Lorem.Sentence (10))
                    .RuleFor (p => p.Slug, f => f.Lorem.Slug (3))
                    .RuleFor (p => p.Description, f => f.Lorem.Sentences (2))
                    .RuleFor (p => p.Body, f => f.Lorem.Paragraph (3))
                    .RuleFor (p => p.CreatedAt, f => f.Date.Recent ())
                    .RuleFor (p => p.UpdatedAt, f => f.Date.Soon ());

                var newPosts = fakePosts.Generate (amount);

                _context.Posts.AddRange (newPosts);
                _context.SaveChanges ();

                var fakePostTags = new Faker<PostTag> ()
                    .RuleFor (p => p.PostId, f => fakePosts.Generate ().Id)
                    .RuleFor (p => p.TagId, f => fakeTags.Generate ().Id);

                var newPostTags = new List<PostTag> ();
                var tId = 1;
                foreach (var post in newPosts) {
                    var pt = new PostTag () {
                        PostId = post.Id,
                        TagId = tId
                    };
                    newPostTags.Add (pt);
                    tId = tId+1;

                    var pt2 = new PostTag () {
                        PostId = post.Id,
                        TagId = tId
                    };
                    newPostTags.Add (pt2);
                }

                _context.PostTags.AddRange (newPostTags);
                _context.SaveChanges ();

                transaction.Commit();

                return true;
            }
        }
    }

}