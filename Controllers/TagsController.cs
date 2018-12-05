using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_rubicon_api.BogusFactories;
using blog_rubicon_api.Models;
using blog_rubicon_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog_rubicon_api.Controllers {
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase {
        private readonly ITagServices _services;

        public TagsController(ITagServices services)
        {
            _services = services;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get () {
            return Ok(_services.GetAllTags());
        }

        [HttpPost]
        public IActionResult Post([FromQuery] int amount){
            return Ok(_services.GenerateData(amount));
        }
    }
}