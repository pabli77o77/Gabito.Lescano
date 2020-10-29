using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdSanare.Context.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evoluciones_Usuario_UsuarioId",
                table: "Evoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenesComplementarios_Usuario_UsuarioId",
                table: "ExamenesComplementarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Usuario_UsuarioId",
                table: "Ingresos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_UsuarioId",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_ExamenesComplementarios_UsuarioId",
                table: "ExamenesComplementarios");

            migrationBuilder.DropIndex(
                name: "IX_Evoluciones_UsuarioId",
                table: "Evoluciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ExamenesComplementarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Evoluciones");

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Servicios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Servicios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Pacientes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Pacientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "ObrasSociales",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "ObrasSociales",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Ingresos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Ingresos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "ExamenesFisicos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "ExamenesFisicos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "ExamenesComplementarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "ExamenesComplementarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Evoluciones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Evoluciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Domicilios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Domicilios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "BajaLogica",
                table: "Camas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Camas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "ExamenesFisicos");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "ExamenesFisicos");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "ExamenesComplementarios");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "ExamenesComplementarios");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Evoluciones");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Evoluciones");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Domicilios");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Domicilios");

            migrationBuilder.DropColumn(
                name: "BajaLogica",
                table: "Camas");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Camas");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Ingresos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "ExamenesComplementarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Evoluciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeFileNumber = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_UsuarioId",
                table: "Ingresos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesComplementarios_UsuarioId",
                table: "ExamenesComplementarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_UsuarioId",
                table: "Evoluciones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evoluciones_Usuario_UsuarioId",
                table: "Evoluciones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenesComplementarios_Usuario_UsuarioId",
                table: "ExamenesComplementarios",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Usuario_UsuarioId",
                table: "Ingresos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
