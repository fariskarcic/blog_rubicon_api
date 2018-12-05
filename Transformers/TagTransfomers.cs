using System.Collections.Generic;
using System.Linq;
using blog_rubicon_api.Models;
using blog_rubicon_api.ViewModels;

namespace blog_rubicon_api.Transformers{
    public class TagTransformers{
        public static TagViewModel TransformIntoVM(List<Tag> tags){
            string[] tagList = tags.Select(t => t.Text).ToArray();
            TagViewModel vm = new TagViewModel(){
                Tags = tagList
            };

            return vm;
        }
    }
}