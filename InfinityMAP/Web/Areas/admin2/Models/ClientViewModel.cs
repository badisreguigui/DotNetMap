using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class ClientViewModel
    {
       

        public int id { get; set; }

        public string categorie { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        

        [StringLength(255)]
        public string logo { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public string typeClient { get; set; }

        public virtual ICollection<projet> projets { get; set; }

      //  public virtual ICollection<resourcerequest> resourcerequests { get; set; }
    }
}