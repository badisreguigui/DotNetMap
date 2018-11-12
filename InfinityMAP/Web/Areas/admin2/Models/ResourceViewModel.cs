using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class ResourceViewModel
    {

        public string DTYPE { get; set; }
        public int id { get; set; }
        public Nullable<int> contractype { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string picture { get; set; }
        public string profil { get; set; }
        public float rating { get; set; }
        public string region { get; set; }
        public string sector { get; set; }
        public string seniority { get; set; }
        public Nullable<int> state { get; set; }
        public string name { get; set; }
        public string stateApplicant { get; set; }
        public Nullable<float> TotalFactureMandat { get; set; }
        public Nullable<float> salaireHoraire { get; set; }
        public int yearsOfExperience { get; set; }
        public string ipAdress { get; set; }
        public int holiday { get; set; }
       
    }
}