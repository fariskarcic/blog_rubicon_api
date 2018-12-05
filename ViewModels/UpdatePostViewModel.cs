using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog_rubicon_api.ViewModels {
    public class UpdatePostViewModel {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string[] Tags { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}