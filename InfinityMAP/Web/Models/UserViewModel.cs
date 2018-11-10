using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {
        public int UtilisateurId { get; set; }
        public string name { get; set; }

        public string prenom { get; set; }

        public int age { get; set; }
    }
}