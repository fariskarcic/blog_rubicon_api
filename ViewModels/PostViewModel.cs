using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog_rubicon_api.ViewModels {
    public class PostViewModel {
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string[] Tags { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}