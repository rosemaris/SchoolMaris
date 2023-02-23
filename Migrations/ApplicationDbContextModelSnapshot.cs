﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolMaris.Model;

namespace SchoolMaris.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolMaris.Model.Level", b =>
                {
                    b.Property<int>("LevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LevelID");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSection", b =>
                {
                    b.Property<int>("LevelSectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LevelID")
                        .HasColumnType("int");

                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.HasKey("LevelSectionID");

                    b.HasIndex("LevelID");

                    b.HasIndex("SectionID");

                    b.ToTable("LevelSection");
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSectionTeacher", b =>
                {
                    b.Property<int>("LevelSectionTeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LevelSectionID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("LevelSectionTeacherID");

                    b.HasIndex("LevelSectionID");

                    b.HasIndex("TeacherID");

                    b.ToTable("LevelSectionTeacher");
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSubject", b =>
                {
                    b.Property<int>("LevelSubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LevelID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("LevelSubjectID");

                    b.HasIndex("LevelID");

                    b.HasIndex("SubjectID");

                    b.ToTable("LevelSubject");
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSubjectTeacher", b =>
                {
                    b.Property<int>("LevelSubjectTeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LevelSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("LevelSubjectTeacherID");

                    b.HasIndex("LevelSubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("LevelSubjectTeacher");
                });

            modelBuilder.Entity("SchoolMaris.Model.Section", b =>
                {
                    b.Property<int>("SectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SectionID");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("SchoolMaris.Model.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("SchoolMaris.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TeacherID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSection", b =>
                {
                    b.HasOne("SchoolMaris.Model.Level", "Level")
                        .WithMany("LevelSections")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMaris.Model.Section", "Section")
                        .WithMany("LevelSections")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSectionTeacher", b =>
                {
                    b.HasOne("SchoolMaris.Model.LevelSection", "LevelSection")
                        .WithMany("LevelSectionTeachers")
                        .HasForeignKey("LevelSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMaris.Model.Teacher", "Teacher")
                        .WithMany("LevelSectionTeachers")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSubject", b =>
                {
                    b.HasOne("SchoolMaris.Model.Level", "Level")
                        .WithMany("LevelSubjects")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMaris.Model.Subject", "Subject")
                        .WithMany("LevelSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolMaris.Model.LevelSubjectTeacher", b =>
                {
                    b.HasOne("SchoolMaris.Model.LevelSubject", "LevelSubject")
                        .WithMany("LevelSubjectTeachers")
                        .HasForeignKey("LevelSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMaris.Model.Teacher", "Teacher")
                        .WithMany("LevelSubjectTeachers")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
