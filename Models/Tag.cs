using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog_rubicon_api.Models {
    public class Tag {
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<PostTag> PostTags { get; set; }
    }
}