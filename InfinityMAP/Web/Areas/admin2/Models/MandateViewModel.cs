using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class MandateViewModel
    {
        public int MandateId { get; set; }
        public Nullable<int> historique_HistoriqueId { get; set; }
        public Nullable<int> request_requestId { get; set; }
        public Nullable<int> resource_id { get; set; }
        public float Facture { get; set; }
        public string NomMandat { get; set; }

        public DateTime date_end_mandate { get; set; }

       

        public DateTime date_start_mandate { get; set; }
        public virtual HistoriqueAssignationMandatViewModel historiqueassignationmandat { get; set; }
        public virtual ResourceRequestViewModel resourcerequest { get; set; }
        public virtual ResourceViewModel resource { get; set; }
    }
}