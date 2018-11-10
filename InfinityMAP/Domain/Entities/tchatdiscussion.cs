namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.tchatdiscussion")]
    public partial class tchatdiscussion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tchatdiscussion()
        {
            tchatmessages = new HashSet<tchatmessage>();
        }

        public int id { get; set; }

        public int recieverID { get; set; }

        public int senderID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tchatmessage> tchatmessages { get; set; }
    }
}
