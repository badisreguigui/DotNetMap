using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {
       
        public string login { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        public string token { get; set; }

    }
}