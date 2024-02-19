using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessCRM.Migrations
{
    /// <inheritdoc />
    public partial class Migration180224 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    adress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    inn = table.Column<long>(type: "bigint", nullable: true),
                    kpp = table.Column<long>(type: "bigint", nullable: true),
                    bank_account = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("suppliers_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    role = table.Column<long>(type: "bigint", nullable: false),
                    employee = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_employee_user",
                        column: x => x.employee,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_role_user",
                        column: x => x.role,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    count = table.Column<long>(type: "bigint", nullable: false),
                    supplier = table.Column<long>(type: "bigint", nullable: true),
                    image = table.Column<uint>(type: "oid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_product",
                        column: x => x.supplier,
                        principalTable: "suppliers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_supplier",
                table: "products",
                column: "supplier");

            migrationBuilder.CreateIndex(
                name: "IX_users_employee",
                table: "users",
                column: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_users_role",
                table: "users",
                column: "role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
