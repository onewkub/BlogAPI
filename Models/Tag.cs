using System;
using System.Collections.Generic;

namespace blogApi.Models
{
    public partial class Tag
    {
        public string Bid { get; set; }
        public string TagName { get; set; }

        public virtual Blog B { get; set; }
    }
}
