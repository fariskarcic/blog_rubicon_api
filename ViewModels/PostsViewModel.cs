using System.Collections.Generic;

namespace blog_rubicon_api.ViewModels{
    public class PostsViewModel{
        public List<PostViewModel> BlogPosts { get; set; }
        public int PostsCount { get; set; }
    }
}