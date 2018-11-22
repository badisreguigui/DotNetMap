using Domain;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context: DbContext
    {
        public Context():base("name=map")
        {

        }

        //DbSet<Utilisateur> users { get; set; }


        public virtual DbSet<applicantanswer> applicantanswers { get; set; }
        public virtual DbSet<applicantfile> applicantfiles { get; set; }
        public virtual DbSet<applicantrequest> applicantrequests { get; set; }
        public virtual DbSet<archiveresource> archiveresources { get; set; }
        public virtual DbSet<arrival> arrivals { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<historiqueassignationmandat> historiqueassignationmandats { get; set; }
        public virtual DbSet<ligneskill> ligneskills { get; set; }
        public virtual DbSet<mandate> mandates { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<messagenotif> messagenotifs { get; set; }
        public virtual DbSet<projet> projets { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<rdv> rdvs { get; set; }
        public virtual DbSet<resource> resources { get; set; }
        public virtual DbSet<resourcerequest> resourcerequests { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<tchatdiscussion> tchatdiscussions { get; set; }
        public virtual DbSet<tchatmessage> tchatmessages { get; set; }
        public virtual DbSet<test> tests { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vacation> vacations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<applicantanswer>()
                .Property(e => e.answer)
                .IsUnicode(false);

            modelBuilder.Entity<applicantrequest>()
                .Property(e => e.speciality)
                .IsUnicode(false);

            modelBuilder.Entity<applicantrequest>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.profil)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<archiveresource>()
                .Property(e => e.sector)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.etat)
                .IsUnicode(false);

           

            modelBuilder.Entity<client>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.projets)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<client>()
                .HasMany(e => e.resourcerequests)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<client>()
              .HasMany(e => e.user)
              .WithOptional(e => e.client)
              .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<historiqueassignationmandat>()
                .Property(e => e.etatMandat)
                .IsUnicode(false);

            modelBuilder.Entity<historiqueassignationmandat>()
                .HasMany(e => e.mandates)
                .WithOptional(e => e.historiqueassignationmandat)
                .HasForeignKey(e => e.historique_HistoriqueId);

            modelBuilder.Entity<ligneskill>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.NomMandat)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.Object)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.messageBody)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.messageType)
                .IsUnicode(false);

            modelBuilder.Entity<messagenotif>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .HasMany(e => e.resourcerequests)
                .WithOptional(e => e.projet)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.user)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.resource_id);

            modelBuilder.Entity<projet>()
                .HasMany(e => e.skills)
                .WithMany(e => e.projets)
                .Map(m => m.ToTable("projet_skills").MapLeftKey("Projet_id").MapRightKey("listSkills_id"));

            modelBuilder.Entity<question>()
                .Property(e => e.answer)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.question1)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.applicantanswers)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.question_id);

            modelBuilder.Entity<question>()
                .HasMany(e => e.resources)
                .WithMany(e => e.questions)
                .Map(m => m.ToTable("question_resource").MapLeftKey("questions_id").MapRightKey("applicants_id"));

            modelBuilder.Entity<resource>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.profil)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.sector)
                .IsUnicode(false);

            

            modelBuilder.Entity<resource>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.stateApplicant)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.ipAdress)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.applicantanswers)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.applicant_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.applicantfiles)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.applicant_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.applicantrequests)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.applicant_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.arrivals)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.applicant_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.mandates)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.resource_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.projets)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.rdvs)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.applicant_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.vacations)
                .WithOptional(e => e.resource)
                .HasForeignKey(e => e.resource_id);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.projets1)
                .WithMany(e => e.resources)
                .Map(m => m.ToTable("projet_resource").MapLeftKey("listResources_id").MapRightKey("Projet_id"));

            modelBuilder.Entity<resource>()
                .HasMany(e => e.skills1)
                .WithMany(e => e.resources)
                .Map(m => m.ToTable("resource_skills").MapLeftKey("listResources_id").MapRightKey("listSkills_id"));

            modelBuilder.Entity<resource>()
                .HasMany(e => e.tests)
                .WithMany(e => e.resources)
                .Map(m => m.ToTable("resource_test").MapLeftKey("Resource_id").MapRightKey("tests_id"));

            modelBuilder.Entity<resource>()
                .HasMany(e => e.tests1)
                .WithMany(e => e.resources1)
                .Map(m => m.ToTable("test_resource").MapLeftKey("applicants_id").MapRightKey("Test_id"));

            modelBuilder.Entity<resourcerequest>()
                .Property(e => e.Director)
                .IsUnicode(false);

            modelBuilder.Entity<resourcerequest>()
                .Property(e => e.EducationScolarity)
                .IsUnicode(false);

            modelBuilder.Entity<resourcerequest>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<resourcerequest>()
                .Property(e => e.requirements)
                .IsUnicode(false);

            modelBuilder.Entity<resourcerequest>()
                .Property(e => e.searchedProfile)
                .IsUnicode(false);

            modelBuilder.Entity<resourcerequest>()
                .HasMany(e => e.mandates)
                .WithOptional(e => e.resourcerequest)
                .HasForeignKey(e => e.request_requestId);

            modelBuilder.Entity<skill>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<tchatdiscussion>()
                .HasMany(e => e.tchatmessages)
                .WithOptional(e => e.tchatdiscussion)
                .HasForeignKey(e => e.tchatdiscussion_id);

            modelBuilder.Entity<tchatmessage>()
                .Property(e => e.msg)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.questions)
                .WithOptional(e => e.test)
                .HasForeignKey(e => e.test_id);

            modelBuilder.Entity<user>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.messagenotifs)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);
        }
    }
}

