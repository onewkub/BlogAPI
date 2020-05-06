using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogApi.Models;

namespace blogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private DBContext dBContext;
        private TagController tagController;
        public BlogController(DBContext _dbContext)
        {
            dBContext = _dbContext;
            tagController = new TagController(_dbContext);
        }

        // GET api/blog
        [HttpGet("")]
        public ActionResult<IEnumerable<Blog>> GetBlog()
        {
            return Ok(dBContext.Blog.ToList<Blog>());
            // return new List<Blog> { null };
        }

        // GET api/blog/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Blog>> GetblogById(string id)
        {
            return Ok(dBContext.Blog.Where(b => b.BlogId == id).ToList<Blog>());
        }

        // POST api/blog
        [HttpPost("")]
        public ActionResult<string> PostBlog(Blog value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    value.BlogId = RandomString._RandomString(64);
                    dBContext.Blog.Add(value);
                    dBContext.SaveChanges();
                    return Ok(value.BlogId);
                }
                return "Connection Problem";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        // PUT api/blog/5
        [HttpPut("{id}")]
        public ActionResult<string> PutBlog(string id, Blog value)
        {
            try
            {
                var obj = dBContext.Blog.Find(id);
                obj.Body = value.Body;
                obj.Title = value.Title;
                dBContext.SaveChanges();
                return "Blog has been updated.";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBlogById(string id)
        {
            dBContext.Blog.Remove(dBContext.Blog.Find(id));
            dBContext.SaveChanges();
            return "Blog had been removed.";
        }

    }
}