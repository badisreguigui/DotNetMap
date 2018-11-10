namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.message")]
    public partial class message
    {
        public int messageId { get; set; }

        [StringLength(255)]
        public string Object { get; set; }

        [StringLength(255)]
        public string messageBody { get; set; }

        [StringLength(255)]
        public string messageType { get; set; }

        public int recieverId { get; set; }

        public int senderId { get; set; }

        public DateTime? sentDate { get; set; }
    }
}
