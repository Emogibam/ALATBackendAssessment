﻿// <auto-generated />
using System;
using BackendAssessment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendAssessment.Infrastructure.Migrations
{
    [DbContext(typeof(BackendAssessmentContext))]
    [Migration("20220712013951_location")]
    partial class location
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendAssessment.Infrastructure.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OPTExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BackendAssessment.Infrastructure.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LGA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BackendAssessment.Infrastructure.Entities.Customer", b =>
                {
                    b.HasOne("BackendAssessment.Infrastructure.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId1");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
