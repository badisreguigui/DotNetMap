namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.tchatmessages")]
    public partial class tchatmessage
    {
        public int id { get; set; }

        [StringLength(255)]
        public string msg { get; set; }

        public int seen { get; set; }

        public int senderID { get; set; }

        public DateTime? sentDate { get; set; }

        public int? tchatdiscussion_id { get; set; }

        public virtual tchatdiscussion tchatdiscussion { get; set; }
    }
}
