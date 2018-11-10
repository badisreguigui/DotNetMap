namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            messagenotifs = new HashSet<messagenotif>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Login { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<messagenotif> messagenotifs { get; set; }
    }
}
