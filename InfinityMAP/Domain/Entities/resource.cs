namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.resource")]
    public partial class resource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resource()
        {
            applicantanswers = new HashSet<applicantanswer>();
            applicantfiles = new HashSet<applicantfile>();
            applicantrequests = new HashSet<applicantrequest>();
            arrivals = new HashSet<arrival>();
            mandates = new HashSet<mandate>();
            projets = new HashSet<projet>();
            rdvs = new HashSet<rdv>();
            skills = new HashSet<skill>();
            vacations = new HashSet<vacation>();
            projets1 = new HashSet<projet>();
            questions = new HashSet<question>();
            skills1 = new HashSet<skill>();
            tests = new HashSet<test>();
            tests1 = new HashSet<test>();
        }

        [Required]
        [StringLength(31)]
        public string DTYPE { get; set; }

        public int id { get; set; }

        public float? TotalFactureMandat { get; set; }

        public int? contractype { get; set; }

        [StringLength(255)]
        public string firstname { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string profil { get; set; }

        public float? rating { get; set; }

        [StringLength(255)]
        public string region { get; set; }

        public float? salaireHoraire { get; set; }

        [StringLength(255)]
        public string sector { get; set; }

        [StringLength(255)]
        public string seniority { get; set; }

        public int? state { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string stateApplicant { get; set; }

        public int? holiday { get; set; }

        [StringLength(255)]
        public string ipAdress { get; set; }

        public int? yearsOfExperience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicantanswer> applicantanswers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicantfile> applicantfiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicantrequest> applicantrequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<arrival> arrivals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projet> projets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rdv> rdvs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vacation> vacations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projet> projets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests1 { get; set; }
    }
}
