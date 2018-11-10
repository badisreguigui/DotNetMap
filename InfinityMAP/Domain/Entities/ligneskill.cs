namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.ligneskill")]
    public partial class ligneskill
    {
        public int id { get; set; }

        public int idResource { get; set; }

        [StringLength(255)]
        public string value { get; set; }
    }
}
