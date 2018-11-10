namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.vacation")]
    public partial class vacation
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateFin { get; set; }

        public int? resource_id { get; set; }

        public virtual resource resource { get; set; }
    }
}
