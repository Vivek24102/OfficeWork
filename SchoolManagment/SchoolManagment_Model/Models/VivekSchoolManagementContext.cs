using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagment_Model.Models;

public partial class VivekSchoolManagementContext : DbContext
{
    public VivekSchoolManagementContext()
    {
    }

    public VivekSchoolManagementContext(DbContextOptions<VivekSchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.88;Database=Vivek_SchoolManagement;User ID=sa;Password=Sit@321#;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC072B07630E");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__City__CountryId__5629CD9C");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("city_ref_State");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07209B2B8D");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__State__3214EC07F06A1E84");

            entity.ToTable("State");

            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__State__CountryId__52593CB8");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__Student__32CE55B13046FA59");

            entity.ToTable("Student");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Emailid)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .HasColumnName("image");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(51)
                .IsUnicode(false);
            entity.Property(e => e.StAddress)
                .IsUnicode(false)
                .HasColumnName("st_Address");
            entity.Property(e => e.StudentName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Teacher)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("City_ref_student");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Country_ref_student");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("State_ref_student");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC07005F6CCA");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC07D79FC89C");

            entity.ToTable("Teacher");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("City_ref_teacher");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Country_ref_teacher");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("State_ref_teacher");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserData__3213E83FC19DAB9F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(151)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(151)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.UserPswd)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
