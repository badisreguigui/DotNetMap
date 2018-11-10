namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.applicantfile")]
    public partial class applicantfile
    {
        public int id { get; set; }

        public float testResult { get; set; }

        public int? applicant_id { get; set; }

        public virtual resource resource { get; set; }
    }
}
