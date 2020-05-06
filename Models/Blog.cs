using System;
using System.Collections.Generic;

namespace blogApi.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Tag = new HashSet<Tag>();
        }

        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
        public DateTimeOffset? UpdateTime { get; set; }

        public virtual ICollection<Tag> Tag { get; set; }
    }
}
