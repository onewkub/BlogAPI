using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using blogApi.Models;
using System.Text.RegularExpressions;
using System.Linq;

namespace blogApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DetectHashtag : ControllerBase
    {

        public DetectHashtag() { }

        [HttpPost("")]
        public static HashSet<string> GetHasTag(StringValue body)
        {
            var regex = new Regex(@"#\w+");
            var matches = regex.Matches(body.value)
            .Cast<Match>()
            .Select(m => m.Value)
            .ToHashSet();
            return matches;
        }

    }
}