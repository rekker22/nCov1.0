using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace nCov1._0.Models
{
    public partial class nCov10Context : DbContext
    {

        public nCov10Context(DbContextOptions<nCov10Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NCovStateData> NCovStateData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if(env == "Development") { 

                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nCov1.0;Integrated Security=True");
                    //optionsBuilder.UseNpgsql("Server=192.168.99.100;Port=5432;User Id=username;Password=secret;Database=todos;");
                }
                else
                {
                    // Use connection string provided at runtime by Heroku.
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                    // Parse connection URL to connection string for Npgsql
                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    //var pgPort = pgHostPort.Split(":")[1];
                    var pgPort = 5432;

                    var connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Require;Trust Server Certificate=true;";
                    optionsBuilder.UseNpgsql(connStr);
                }
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
