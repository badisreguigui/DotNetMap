using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class ApplicantRequest
    {
        public int requestId { get; set; }

        public DateTime date { get; set; }

        public string speciality { get; set; }
        public string state { get; set; }
        public int vu { get; set; }
        //public Employe applicant { get; set; }

        // private Requeststate state;
    }
}