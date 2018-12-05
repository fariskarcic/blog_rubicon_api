using blog_rubicon_api.ViewModels;

namespace blog_rubicon_api.Services
{
    public interface ITagServices
    {
        TagViewModel GetAllTags();
        bool GenerateData(int amount);
    }
}