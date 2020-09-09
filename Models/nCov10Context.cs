using Microsoft.EntityFrameworkCore;

namespace nCov1._0.Models
{
    public partial class nCov10Context : DbContext
    {
        public nCov10Context()
        {
        }

        public nCov10Context(DbContextOptions<nCov10Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NCovStateData> NCovStateData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nCov1.0;Integrated Security=True");
                optionsBuilder.UseNpgsql("Server=192.168.99.100;Port=5432;User Id=username;Password=secret;Database=todos;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NCovStateData>(entity =>
            {
                entity.HasKey(e => e.SdCode)
                    .HasName("PK__tmp_ms_x__A3801A317F3F7A1E");

                entity.ToTable("nCovStateData");

                entity.Property(e => e.SdCode)
                    .HasColumnName("sdCode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DName)
                    .IsRequired()
                    .HasColumnName("dName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("sName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
