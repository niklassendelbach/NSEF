﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSEF.Data;

#nullable disable

namespace NSEF.Migrations
{
    [DbContext(typeof(NSEFDBContext))]
    [Migration("20230418110208_firstTables")]
    partial class firstTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NSEF.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceId"));

                    b.Property<string>("AbsenceType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AbsenceId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("NSEF.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NSEF.Models.EmployeeAbsence", b =>
                {
                    b.Property<int>("EmployeeAbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeAbsenceId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_AbsenceId")
                        .HasColumnType("int");

                    b.Property<int>("FK_EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeAbsenceId");

                    b.HasIndex("FK_AbsenceId");

                    b.HasIndex("FK_EmployeeId");

                    b.ToTable("EmployeeAbsences");
                });

            modelBuilder.Entity("NSEF.Models.EmployeeAbsence", b =>
                {
                    b.HasOne("NSEF.Models.Absence", "Absences")
                        .WithMany("EmployeeAbsences")
                        .HasForeignKey("FK_AbsenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSEF.Models.Employee", "Employees")
                        .WithMany("EmployeeAbsences")
                        .HasForeignKey("FK_EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Absences");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NSEF.Models.Absence", b =>
                {
                    b.Navigation("EmployeeAbsences");
                });

            modelBuilder.Entity("NSEF.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAbsences");
                });
#pragma warning restore 612, 618
        }
    }
}
