using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdSanare.Context.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Domicilio_DomicilioId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObraSocial_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObraSocial",
                table: "ObraSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domicilio",
                table: "Domicilio");

            migrationBuilder.RenameTable(
                name: "ObraSocial",
                newName: "ObrasSociales");

            migrationBuilder.RenameTable(
                name: "Domicilio",
                newName: "Domicilios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObrasSociales",
                table: "ObrasSociales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domicilios",
                table: "Domicilios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExamenesFisicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoActual = table.Column<string>(nullable: true),
                    FrecuenciaCardiaca = table.Column<int>(nullable: false),
                    TensionArterial = table.Column<string>(nullable: true),
                    FrecuenciaRespiratoria = table.Column<int>(nullable: false),
                    SaturacionOxigeno = table.Column<int>(nullable: false),
                    Temperatura = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesFisicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployeeFileNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioInternacionId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camas_Servicios_ServicioInternacionId",
                        column: x => x.ServicioInternacionId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamenesComplementarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: true),
                    FechaExamen = table.Column<DateTime>(nullable: false),
                    TipoExamen = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesComplementarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenesComplementarios_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamenesComplementarios_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    FechaEgreso = table.Column<DateTime>(nullable: false),
                    Defuncion = table.Column<bool>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: true),
                    AntecedentesMedicos = table.Column<string>(nullable: true),
                    AntecedentesQuirurgicos = table.Column<string>(nullable: true),
                    Alergias = table.Column<string>(nullable: true),
                    MedicacionHabitual = table.Column<string>(nullable: true),
                    Peso = table.Column<decimal>(nullable: false),
                    Talla = table.Column<decimal>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingresos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evoluciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEvolucion = table.Column<DateTime>(nullable: false),
                    IngresoId = table.Column<int>(nullable: true),
                    ServicioInternacionId = table.Column<int>(nullable: true),
                    CamaInternacionId = table.Column<int>(nullable: true),
                    ExamenFisicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evoluciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Camas_CamaInternacionId",
                        column: x => x.CamaInternacionId,
                        principalTable: "Camas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evoluciones_ExamenesFisicos_ExamenFisicoId",
                        column: x => x.ExamenFisicoId,
                        principalTable: "ExamenesFisicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Ingresos_IngresoId",
                        column: x => x.IngresoId,
                        principalTable: "Ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Servicios_ServicioInternacionId",
                        column: x => x.ServicioInternacionId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camas_ServicioInternacionId",
                table: "Camas",
                column: "ServicioInternacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_CamaInternacionId",
                table: "Evoluciones",
                column: "CamaInternacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_ExamenFisicoId",
                table: "Evoluciones",
                column: "ExamenFisicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_IngresoId",
                table: "Evoluciones",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_ServicioInternacionId",
                table: "Evoluciones",
                column: "ServicioInternacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_UsuarioId",
                table: "Evoluciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesComplementarios_PacienteId",
                table: "ExamenesComplementarios",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesComplementarios_UsuarioId",
                table: "ExamenesComplementarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_PacienteId",
                table: "Ingresos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_UsuarioId",
                table: "Ingresos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Domicilios_DomicilioId",
                table: "Pacientes",
                column: "DomicilioId",
                principalTable: "Domicilios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId",
                principalTable: "ObrasSociales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Domicilios_DomicilioId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Evoluciones");

            migrationBuilder.DropTable(
                name: "ExamenesComplementarios");

            migrationBuilder.DropTable(
                name: "Camas");

            migrationBuilder.DropTable(
                name: "ExamenesFisicos");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObrasSociales",
                table: "ObrasSociales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domicilios",
                table: "Domicilios");

            migrationBuilder.RenameTable(
                name: "ObrasSociales",
                newName: "ObraSocial");

            migrationBuilder.RenameTable(
                name: "Domicilios",
                newName: "Domicilio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObraSocial",
                table: "ObraSocial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domicilio",
                table: "Domicilio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Domicilio_DomicilioId",
                table: "Pacientes",
                column: "DomicilioId",
                principalTable: "Domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObraSocial_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId",
                principalTable: "ObraSocial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
