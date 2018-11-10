namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.rdv")]
    public partial class rdv
    {
        public int id { get; set; }

        public DateTime? rdvDate { get; set; }

        public int? state { get; set; }

        public int? applicant_id { get; set; }

        public virtual resource resource { get; set; }
    }
}
