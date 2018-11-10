namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.resourcerequest")]
    public partial class resourcerequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resourcerequest()
        {
            mandates = new HashSet<mandate>();
        }

        [Key]
        public int requestId { get; set; }

        [StringLength(255)]
        public string Director { get; set; }

        [StringLength(255)]
        public string EducationScolarity { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public DateTime? depotDate { get; set; }

        public int? depotHour { get; set; }

        [Column(TypeName = "date")]
        public DateTime? mandateEndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? mandateStartDate { get; set; }

        [StringLength(255)]
        public string requirements { get; set; }

        [StringLength(255)]
        public string searchedProfile { get; set; }

        public int? yearsOfExperience { get; set; }

        public int? client_id { get; set; }

        public int? project_id { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        public virtual projet projet { get; set; }
    }
}
