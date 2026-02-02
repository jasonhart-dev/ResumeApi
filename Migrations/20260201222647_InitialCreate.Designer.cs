using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResumeApi.Data;

#nullable disable

namespace ResumeApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260201222647_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResumeApi.Models.VisitCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long>("TotalVisits")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("VisitCounters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdated = new DateTime(2026, 2, 1, 16, 0, 0, 0, DateTimeKind.Utc),
                            TotalVisits = 0L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
