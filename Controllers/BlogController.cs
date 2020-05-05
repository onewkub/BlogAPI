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
        private DBContext dBContext = new DBContext();
        public BlogController()
        {
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
        public void PostBlog(Blog value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    value.BlogId = RandomString(64);
                    dBContext.Blog.Add(value);
                    dBContext.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // PUT api/blog/5
        [HttpPut("{id}")]
        public void PutBlog(string id, dynamic value)
        {
            try
            {
                var obj = dBContext.Blog.Find(id);
                obj.Body = value.Body;
                obj.Title = value.Title;
                dBContext.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
        public void DeleteBlogById(string id)
        {
            dBContext.Blog.Remove(dBContext.Blog.Find(id));
            dBContext.SaveChanges();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnop0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}