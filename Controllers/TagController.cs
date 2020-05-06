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
        
        [HttpPost("{id}")]
        public ActionResult<string> AddTag(string id, HashSet<string> Hashtag)
        {
            try
            {
                foreach (var item in Hashtag)
                {
                    var _tagname = item.Trim('#');

                    var _tag = new Tag(){
                        Bid = id,
                        TagName = _tagname
                    };
                    dBContext.Add(_tag);
                }
                dBContext.SaveChanges();
                return Ok("ok");

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }

        }



}
}