using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogApi.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace blogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TagController : ControllerBase
    {
        private DBContext dBContext;

        public TagController(DBContext _db)
        {
            dBContext = _db;
        }

        [HttpGet("{tagName}")]
        public ActionResult<IEnumerable<string>> GetBlogContainTag(string tagName)
        {                
            // return Ok(new List<string> {tagName});
            try
            {
                return Ok(
                    dBContext.Blog.Where(b => 
                    dBContext.Tag
                    .Where(tag => tag.TagName == tagName)
                    .Select(tag => tag.Bid)
                    .Distinct().Contains(b.BlogId))
                    .OrderByDescending(b => b.CreateTime)
                    .ToList()
                    );

            }
            catch (Exception ex)
            {
                
                return Ok(ex);
            }
            
        }

        [HttpGet("rank")]

        public ActionResult<IEnumerable<dynamic>> GetTagRanking(){
            try
            {
                return Ok(dBContext.Tag
                .GroupBy(t => t.TagName)
                .Select(t => new {tagName = t.Key, count = t.Count()})
                .OrderBy(t => t.count)
                );
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        
        [HttpPost("")]
        public ActionResult<string> AddTag(List<Tag> Hashtag)
        {
            try
            {
                dBContext.AddRange(Hashtag);
                dBContext.SaveChanges();
                return Ok(Hashtag);

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
            // return Ok(Hashtag);

        }



}
}