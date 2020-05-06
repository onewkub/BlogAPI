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
        public ActionResult<IEnumerable<string>> GetBlogIDContainTag(string tagName)
        {                
            // return Ok(new List<string> {tagName});
            try
            {
                return Ok(dBContext.Tag.Where(tag => tag.TagName == tagName).Select(tag => tag.Bid).Distinct().ToList());
            }
            catch (Exception ex)
            {
                
                return Ok(ex);
            }
            
        }
        
        [HttpPost("")]
        public ActionResult<string> AddTag(List<Tag> Hashtag)
        {
            try
            {
                // // var htList = new HashSet<string>(Hashtag.value);
                // foreach (var item in Hashtag)
                // {
                //     var _tagname = item..Trim('#');

                //     var _tag = new Tag(){
                //         Bid = id,
                //         TagName = _tagname
                //     };
                //     dBContext.Add(_tag);
                // }
                // dBContext.AddRange(Hashtag);
                // foreach (var item in Hashtag)
                // {
                //     dBContext.Add(item);
                // }
                dBContext.AddRange(Hashtag);
                dBContext.SaveChanges();
                return Ok("ok");

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
            // return Ok(Hashtag);

        }



}
}