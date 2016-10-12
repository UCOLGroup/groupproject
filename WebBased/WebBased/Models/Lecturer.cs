using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBased.Models
{
    public class Lecturer
    {
        public int lecturer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int extension { get; set; }
        public string qualification { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }

    }
}