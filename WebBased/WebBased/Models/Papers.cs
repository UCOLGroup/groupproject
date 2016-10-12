using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBased.Models
{
    public class Papers
    { public int paper_id { get; set; }
        public string code { get; set; } 
        public string paper_name { get; set; }
        public string category { get; set; }
        public int level { get; set; }
        public int credits { get; set;}
        public int lecturer_id { get; set; }
    }
}