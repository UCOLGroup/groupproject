using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBased.Models
{
    public class Student_Papers
    {
        public int paper_id { get; set; }
        public int student_id { get; set; }
        public int study_year { get; set; }
        public int percentage { get; set; }
        public int semester { get; set; }

    }
}