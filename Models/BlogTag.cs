using System;
using System.Collections.Generic;

namespace blogApi.Models
{
    public partial class BlogTag
    {
        public string Bid { get; set; }
        public string Tid { get; set; }

        public virtual Blog B { get; set; }
        public virtual Tag T { get; set; }
    }
}
