using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Model.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Myuser> Myusers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Tasklog> Tasklogs { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.88;Database=employee;User ID=sa;Password=Sit@321#;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__BE2D26B6B002DD6E");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.DeptName)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Emplooyeid).HasName("PK__Employee__1566A2DEA4DB61C1");

            entity.ToTable("Employee");

            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Emailid)
                .HasMaxLength(51)
                .IsUnicode(false);
            entity.Property(e => e.EmpAddress).IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("FK_PersonOrder");
        });

        modelBuilder.Entity<Myuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__myuser__3213E83F018CC459");

            entity.ToTable("myuser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserName)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.Useremail)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("useremail");
            entity.Property(e => e.Usermobileno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usermobileno");
            entity.Property(e => e.Userpswd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userpswd");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Myusers)
                .HasForeignKey(d => d.UserRole)
                .HasConstraintName("FK_Myuser");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task__3213E83FFE6598DC");

            entity.ToTable("task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TaskDescription).IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(201)
                .IsUnicode(false);
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_user");
        });

        modelBuilder.Entity<Tasklog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasklog__3213E83F77324513");

            entity.ToTable("tasklog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Logdate)
                .HasColumnType("date")
                .HasColumnName("logdate");
            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.TaskLog1)
                .IsUnicode(false)
                .HasColumnName("taskLog");

            entity.HasOne(d => d.Task).WithMany(p => p.Tasklogs)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_log");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("PK__userrole__8AF5CA327B02347E");

            entity.ToTable("userrole");

            entity.Property(e => e.RoleName)
                .HasMaxLength(151)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
