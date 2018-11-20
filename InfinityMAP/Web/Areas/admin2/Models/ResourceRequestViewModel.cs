using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class ResourceRequestViewModel
    {
        [Key]
        public int requestId { get; set; }


        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string requirements { get; set; }

        [StringLength(255)]
        public string searchedProfile { get; set; }

        public int? yearsOfExperience { get; set; }

        public virtual client client { get; set; }

        public virtual projet projet { get; set; }
    }
}