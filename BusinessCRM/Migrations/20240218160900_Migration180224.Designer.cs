﻿// <auto-generated />
using System;
using BusinessCRM.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessCRM.Migrations
{
    [DbContext(typeof(CoreModel))]
    [Migration("20240218160900_Migration180224")]
    partial class Migration180224
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BusinessCRM.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("clients_pkey");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("employee_pkey");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<long>("Count")
                        .HasColumnType("bigint")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<uint?>("Image")
                        .HasColumnType("oid")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<long?>("Supplier")
                        .HasColumnType("bigint")
                        .HasColumnName("supplier");

                    b.HasKey("Id")
                        .HasName("products_pkey");

                    b.HasIndex("Supplier");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("roles_pkey");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("adress");

                    b.Property<string>("BankAccount")
                        .HasColumnType("character varying")
                        .HasColumnName("bank_account");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<long?>("Inn")
                        .HasColumnType("bigint")
                        .HasColumnName("inn");

                    b.Property<long?>("Kpp")
                        .HasColumnType("bigint")
                        .HasColumnName("kpp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("suppliers_pkey");

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("Employee")
                        .HasColumnType("bigint")
                        .HasColumnName("employee");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<long>("Role")
                        .HasColumnType("bigint")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.HasIndex("Employee");

                    b.HasIndex("Role");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("BusinessCRM.Product", b =>
                {
                    b.HasOne("BusinessCRM.Supplier", "SupplierNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Supplier")
                        .HasConstraintName("fk_supplier_product");

                    b.Navigation("SupplierNavigation");
                });

            modelBuilder.Entity("BusinessCRM.User", b =>
                {
                    b.HasOne("BusinessCRM.Employee", "EmployeeNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Employee")
                        .IsRequired()
                        .HasConstraintName("fk_employee_user");

                    b.HasOne("BusinessCRM.Role", "RoleNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Role")
                        .IsRequired()
                        .HasConstraintName("fk_role_user");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("RoleNavigation");
                });

            modelBuilder.Entity("BusinessCRM.Employee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessCRM.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessCRM.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
