namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.projet")]
    public partial class projet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projet()
        {
            resourcerequests = new HashSet<resourcerequest>();
            resources = new HashSet<resource>();
            skills = new HashSet<skill>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetEndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetStartDate { get; set; }

        public string statut { get; set; }

        public int? client_id { get; set; }

        public int? ressource_id { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resourcerequest> resourcerequests { get; set; }

        public virtual resource resource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource> resources { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills { get; set; }
    }
}
