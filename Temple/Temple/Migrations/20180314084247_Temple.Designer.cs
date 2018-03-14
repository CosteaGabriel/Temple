﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Temple.Data;

namespace Temple.Migrations
{
    [DbContext(typeof(TempleContext))]
    [Migration("20180314084247_Temple")]
    partial class Temple
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Temple.Models.Distribution", b =>
                {
                    b.Property<int>("DistributionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DoctorID");

                    b.Property<int>("PacientID");

                    b.HasKey("DistributionID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PacientID");

                    b.ToTable("Distribution");
                });

            modelBuilder.Entity("Temple.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Temple.Models.Pacient", b =>
                {
                    b.Property<int>("PacientID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.HasKey("PacientID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Temple.Models.Distribution", b =>
                {
                    b.HasOne("Temple.Models.Doctor", "Doctor")
                        .WithMany("Distributions")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Temple.Models.Pacient", "Pacient")
                        .WithMany("Distributions")
                        .HasForeignKey("PacientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
