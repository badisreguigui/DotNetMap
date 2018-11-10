namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.mandate")]
    public partial class mandate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MandateId { get; set; }

        public float Facture { get; set; }

        [StringLength(255)]
        public string NomMandat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_end_mandate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_start_mandate { get; set; }

        public int? historique_HistoriqueId { get; set; }

        public int? request_requestId { get; set; }

        public int? resource_id { get; set; }

        public virtual historiqueassignationmandat historiqueassignationmandat { get; set; }

        public virtual resourcerequest resourcerequest { get; set; }

        public virtual resource resource { get; set; }
    }
}
