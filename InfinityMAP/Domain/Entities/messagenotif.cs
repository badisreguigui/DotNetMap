namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.messagenotif")]
    public partial class messagenotif
    {
        public int messageNotifId { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int seen { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
