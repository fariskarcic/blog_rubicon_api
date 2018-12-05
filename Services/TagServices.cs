using System.Collections.Generic;
using System.Linq;
using blog_rubicon_api.BogusFactories;
using blog_rubicon_api.Models;
using blog_rubicon_api.Transformers;
using blog_rubicon_api.ViewModels;

namespace blog_rubicon_api.Services
{
    public class TagServices : ITagServices
    {
        private readonly BlogContext _context;

        public TagServices(BlogContext context)
        {
            _context = context;
        }

        public TagViewModel GetAllTags()
        {
            return TagTransformers.TransformIntoVM(_context.Tags.ToList());
        }

        public bool GenerateData (int amount){
            var factory = new Factory(_context);
            return factory.Create(amount);
        }
    }
}