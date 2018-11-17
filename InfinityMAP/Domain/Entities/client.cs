namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            projets = new HashSet<projet>();
           // resourcerequests = new HashSet<resourcerequest>();
        }

        public int id { get; set; }

        public string categorie { get; set; }

        [StringLength(255)]
        public string etat { get; set; }



        [StringLength(255)]
        public string logo { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public string typeClient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projet> projets { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resourcerequest> resourcerequests { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }

        /* [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
         public virtual ICollection<resourcerequest> resourcerequests { get; set; }
     } */

    }
    
}

