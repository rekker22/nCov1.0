﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nCov1._0.Models;

namespace nCov1._0.Migrations
{
    [DbContext(typeof(nCov10Context))]
    [Migration("20230107102240_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nCov1._0.Models.NCovStateData", b =>
                {
                    b.Property<string>("SdCode")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("sdCode");

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("dName");

                    b.Property<double>("LatCoordinates")
                        .HasColumnType("float");

                    b.Property<double>("LongCoordinates")
                        .HasColumnType("float");

                    b.Property<string>("SName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("sName");

                    b.Property<long>("TotalCases")
                        .HasColumnType("bigint");

                    b.HasKey("SdCode")
                        .HasName("PK__tmp_ms_x__A3801A317F3F7A1E");

                    b.ToTable("nCovStateData");
                });
#pragma warning restore 612, 618
        }
    }
}
