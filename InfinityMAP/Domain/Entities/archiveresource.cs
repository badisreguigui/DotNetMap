namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.archiveresources")]
    public partial class archiveresource
    {
        public int id { get; set; }

        public int? contractype { get; set; }

        [StringLength(255)]
        public string firstname { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string profil { get; set; }

        public float rating { get; set; }

        [StringLength(255)]
        public string region { get; set; }

        [StringLength(255)]
        public string sector { get; set; }

        public int seniority { get; set; }

        public int? state { get; set; }
    }
}
