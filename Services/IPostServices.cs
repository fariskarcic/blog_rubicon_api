using System.Collections.Generic;
using blog_rubicon_api.Models;
using blog_rubicon_api.ViewModels;

namespace blog_rubicon_api.Services
{
    public interface IPostServices
    {
        PostsViewModel GetAllPosts(string tag = null);
        PostViewModel AddPost(PostViewModel post);
        PostViewModel GetPostBySlug(string slug);
        PostViewModel UpdatePost(string slug, UpdatePostViewModel post);
        bool RemovePost(string slug);
    }
}