using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ResourceViewModelDetails
    {
        public int id { get; set; }

        public float? totalFactureMandat { get; set; }
        public string contractype { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string picture { get; set; }

        public string profil { get; set; }

        public float? rating { get; set; }

        public string region { get; set; }

        public float? salaireHoraire { get; set; }

        public string sector { get; set; }

        public int seniority { get; set; }

        public string state { get; set; }


        public int? holiday { get; set; }


      



    }
}