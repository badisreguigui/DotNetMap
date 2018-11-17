using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int nbQuestions { get; set; }
    }
}