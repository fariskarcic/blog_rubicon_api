using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog_rubicon_api.Models {
    public class Post {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<PostTag> Tags { get; set; }
    }
}