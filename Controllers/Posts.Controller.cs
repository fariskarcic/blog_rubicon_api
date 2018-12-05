using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_rubicon_api.Models;
using blog_rubicon_api.Services;
using blog_rubicon_api.Transformers;
using blog_rubicon_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog_rubicon_api.Controllers {
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase {
        private readonly IPostServices _services;

        public PostsController (IPostServices services) {
            _services = services;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetAll ([FromQuery] string tag = null) {
            var posts = _services.GetAllPosts (tag);
            return Ok (posts);
        }

        // GET api/values/5
        [HttpGet ("{slug}")]
        public IActionResult Get (string slug) {
            var post = _services.GetPostBySlug (slug);

            if (post == null) {
                return StatusCode (404, new { message = "Post not found" });
            }

            return Ok (post);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post ([FromBody] PostViewModel post) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var p = _services.AddPost (post);

            if (p == null) {
                return StatusCode (409, new { message = "Slug/title already exists" });
            }

            return CreatedAtAction ("Get", new { slug = p.Slug }, p);
        }

        // PUT api/values/5
        [HttpPut ("{slug}")]
        public IActionResult Put (string slug, [FromBody] UpdatePostViewModel post) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var res = _services.UpdatePost (slug, post);

            if (res == null) {
                return StatusCode (409, new { message = "Slug/title already exists" });
            }

            return Ok (res);
        }

        // DELETE api/values/5
        [HttpDelete ("{slug}")]
        public ActionResult<Post> Delete (string slug) {
            var res = _services.RemovePost (slug);

            if (res == true) {
                return Ok (new { message = "Post successfully removed" });
            } else {
                return StatusCode (500, new { message = "Error while trying to remove post, post might not exist" });
            }
        }
    }
}