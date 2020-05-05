using System;
using System.Collections.Generic;

namespace blogApi.Models
{
    public partial class StringValue
    {
        public StringValue()
        {

        }

        public StringValue(string val){
            value = val;
        }

        public string value {get; set;}

    }
}
