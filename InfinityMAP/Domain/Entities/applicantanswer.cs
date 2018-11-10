namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.applicantanswer")]
    public partial class applicantanswer
    {
        public int id { get; set; }

        [StringLength(255)]
        public string answer { get; set; }

        public int? applicant_id { get; set; }

        public int? question_id { get; set; }

        public virtual resource resource { get; set; }

        public virtual question question { get; set; }
    }
}
