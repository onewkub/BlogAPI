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

        public void AddTag(string BlogID, List<string> Hashtag){
            
        }

    }
}