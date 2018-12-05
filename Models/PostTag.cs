using System.ComponentModel.DataAnnotations.Schema;

namespace blog_rubicon_api.Models {
    public class PostTag {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}