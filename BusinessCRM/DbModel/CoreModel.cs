using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessCRM.DbModel;

public partial class CoreModel : DbContext
{
    private static CoreModel instance;
    public static CoreModel init()
    {
        if (instance == null)
        {
            instance = new CoreModel();
        }
        return instance;
    }
    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dbbusinesscrm;Username=postgres;Password=zlobin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("oid")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Supplier).HasColumnName("supplier");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplier)
                .HasConstraintName("fk_supplier_product");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(100)
                .HasColumnName("adress");
            entity.Property(e => e.BankAccount)
                .HasColumnType("character varying")
                .HasColumnName("bank_account");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Kpp).HasColumnName("kpp");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_user");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
