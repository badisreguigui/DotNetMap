namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.question")]
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            applicantanswers = new HashSet<applicantanswer>();
            resources = new HashSet<resource>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string answer { get; set; }

        [Column("question")]
        [StringLength(255)]
        public string question1 { get; set; }

        public int? test_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicantanswer> applicantanswers { get; set; }

        public virtual test test { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource> resources { get; set; }
    }
}
