using System;
using System.Collections.Generic;
using GraduateAppProject.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppProject.Infrastructure.Data;

public partial class CitizensInfoApiDbContext : DbContext
{
    public CitizensInfoApiDbContext()
    {
    }

    public CitizensInfoApiDbContext(DbContextOptions<CitizensInfoApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlesExam> AlesExams { get; set; }

    public virtual DbSet<BachelorDegree> BachelorDegrees { get; set; }

    public virtual DbSet<Citizen> Citizens { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DoctorateDegree> DoctorateDegrees { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<GraduateMajor> GraduateMajors { get; set; }

    public virtual DbSet<Institute> Institutes { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<MasterDegree> MasterDegrees { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    public virtual DbSet<YdsExam> YdsExams { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=AKDEMIR-DESKTOP\\SQLEXPRESS;Database=CitizensInfoApiDB;Trusted_Connection=True;TrustServerCertificate=True;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlesExam>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlesEsitAgirlikGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.AlesSayisalGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.AlesSozelGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DocumentUrl).HasColumnName("DocumentURL");

            entity.HasOne(d => d.Citizen).WithMany(p => p.AlesExams)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlesExams_Citizens");
        });

        modelBuilder.Entity<BachelorDegree>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DegreeGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DiplomaUrl).HasColumnName("DiplomaURL");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TranscriptUrl).HasColumnName("TranscriptURL");

            entity.HasOne(d => d.Citizen).WithMany(p => p.BachelorDegrees)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BachelorDegrees_Citizens");

            entity.HasOne(d => d.Department).WithMany(p => p.BachelorDegrees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BachelorDegrees_Departments");

            entity.HasOne(d => d.Language).WithMany(p => p.BachelorDegrees)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BachelorDegrees_Languages");
        });

        modelBuilder.Entity<Citizen>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.BirthPlace).HasMaxLength(50);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MotherName).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Faculties");

            entity.HasOne(d => d.University).WithMany(p => p.Departments)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Universities");
        });

        modelBuilder.Entity<DoctorateDegree>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiplomaUrl).HasColumnName("DiplomaURL");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Citizen).WithMany(p => p.DoctorateDegrees)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorateDegrees_Citizens");

            entity.HasOne(d => d.GraduateMajor).WithMany(p => p.DoctorateDegrees)
                .HasForeignKey(d => d.GraduateMajorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorateDegrees_GraduateMajors");

            entity.HasOne(d => d.Language).WithMany(p => p.DoctorateDegrees)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorateDegrees_Languages");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.University).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Faculties_Universities");
        });

        modelBuilder.Entity<GraduateMajor>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Institute).WithMany(p => p.GraduateMajors)
                .HasForeignKey(d => d.InstituteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GraduateMajors_Institutes");
        });

        modelBuilder.Entity<Institute>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Language1)
                .HasMaxLength(50)
                .HasColumnName("Language");
        });

        modelBuilder.Entity<MasterDegree>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DegreeGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DiplomaUrl).HasColumnName("DiplomaURL");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TranscriptUrl).HasColumnName("TranscriptURL");

            entity.HasOne(d => d.Citizen).WithMany(p => p.MasterDegrees)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterDegrees_Citizens");

            entity.HasOne(d => d.Department).WithMany(p => p.MasterDegrees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterDegrees_Departments");

            entity.HasOne(d => d.Language).WithMany(p => p.MasterDegrees)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterDegrees_Languages");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<YdsExam>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentUrl).HasColumnName("DocumentURL");
            entity.Property(e => e.YdsGrade).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Citizen).WithMany(p => p.YdsExams)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YdsExams_Citizens");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
