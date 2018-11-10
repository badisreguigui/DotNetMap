namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.applicantrequest")]
    public partial class applicantrequest
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string speciality { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public int? applicant_id { get; set; }

        public virtual resource resource { get; set; }
    }
}
