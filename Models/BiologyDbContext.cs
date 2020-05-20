
using BiologyManagement.Models.LoincFrance;
using BiologyManagement.Models.LoincFrance.EnumTable;
using Microsoft.EntityFrameworkCore;
using VersionActe = BiologyManagement.Models.LoincFrance.EnumTable.VersionActe;

namespace BiologyManagement.API.Models
{
    public class BiologyDbContext : DbContext
    {
        public BiologyDbContext(DbContextOptions<BiologyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //TD
            modelBuilder.Entity<ActeBiologique>().ToTable("TD_ActeBiologique");
            modelBuilder.Entity<Remplacement>().ToTable("TD_Remplacement");
            modelBuilder.Entity<Remplacement>().HasKey(t => new { t.ActeBiologiqueId, t.ActeId });
            //TJ
            modelBuilder.Entity<ActebiologiqueVersion>().ToTable("TJ_ActebiologiqueVersion");

            modelBuilder.Entity<ActebiologiqueVersion>().HasKey(t => new { t.ActeBiologiqueId, t.VersionId });

            modelBuilder.Entity<ActebiologiqueVersion>()
                .HasOne(pt => pt.Version)
                .WithMany(p => p.ActebiologiqueVersions)
                .HasForeignKey(pt => pt.VersionId);

            modelBuilder.Entity<ActebiologiqueVersion>()
                .HasOne(pt => pt.ActeBiologique)
                .WithMany(t => t.ActebiologiqueVersions)
                .HasForeignKey(pt => pt.ActeBiologiqueId);

            //TR
            modelBuilder.Entity<Chapitre>().ToTable("TR_Chapitre");
            modelBuilder.Entity<Echelle>().ToTable("TR_Echelle");
            modelBuilder.Entity<Grandeur>().ToTable("TR_Grandeur");
            modelBuilder.Entity<MilieuBiologique>().ToTable("TR_MilieuBiologique");
            modelBuilder.Entity<Technique>().ToTable("TR_Technique");
            modelBuilder.Entity<Temps>().ToTable("TR_Temps");
            modelBuilder.Entity<Statut>().ToTable("TR_Statut");
            modelBuilder.Entity<VersionActe>().ToTable("TR_Version");
        }

        //TD
        public DbSet<ActeBiologique> ActeBiologiques { get; set; }
        public DbSet<Remplacement> Remplacements { get; set; }
        //TJ
        public DbSet<ActebiologiqueVersion> ActebiologiqueVersions { get; set; }

        //
        public DbSet<Chapitre> Chapitres { get; set; }
        public DbSet<Echelle> Echelles { get; set; }
        public DbSet<Grandeur> Grandeurs { get; set; }
        public DbSet<MilieuBiologique> MilieuBiologiques { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Temps> Temps { get; set; }
        //
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<VersionActe> Versions { get; set; }

    }
}
