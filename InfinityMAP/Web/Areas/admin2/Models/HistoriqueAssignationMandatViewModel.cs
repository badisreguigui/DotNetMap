using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.admin2.Models
{
    public class HistoriqueAssignationMandatViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HistoriqueAssignationMandatViewModel()
        {
            mandates = new HashSet<mandate>();
        }
          
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HistoriqueId { get; set; }

        public DateTime? HeureSauvegarde { get; set; }

        [StringLength(255)]
        public string etatMandat { get; set; }
        [StringLength(255)]
        public string action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }
    }
}