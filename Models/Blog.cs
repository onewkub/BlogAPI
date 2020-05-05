using System;
using System.Collections.Generic;

namespace blogApi.Models
{
    public partial class Blog
    {
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreateTime { get; set; }
    }
}
