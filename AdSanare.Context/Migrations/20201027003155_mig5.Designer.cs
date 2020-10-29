﻿// <auto-generated />
using System;
using AdSanare.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdSanare.Context.Migrations
{
    [DbContext(typeof(AdSanareDbContext))]
    [Migration("20201027003155_mig5")]
    partial class mig5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdSanare.Entities.Cama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServicioInternacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicioInternacionId");

                    b.ToTable("Camas");
                });

            modelBuilder.Entity("AdSanare.Entities.Domicilio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domicilios");
                });

            modelBuilder.Entity("AdSanare.Entities.Evolucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<int?>("CamaInternacionId")
                        .HasColumnType("int");

                    b.Property<int?>("ExamenFisicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEvolucion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IngresoId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicioInternacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CamaInternacionId");

                    b.HasIndex("ExamenFisicoId");

                    b.HasIndex("IngresoId");

                    b.HasIndex("ServicioInternacionId");

                    b.ToTable("Evoluciones");
                });

            modelBuilder.Entity("AdSanare.Entities.ExamenComplementario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Detalle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaExamen")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("TipoExamen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("ExamenesComplementarios");
                });

            modelBuilder.Entity("AdSanare.Entities.ExamenFisico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoActual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrecuenciaCardiaca")
                        .HasColumnType("int");

                    b.Property<int>("FrecuenciaRespiratoria")
                        .HasColumnType("int");

                    b.Property<int>("SaturacionOxigeno")
                        .HasColumnType("int");

                    b.Property<decimal>("Temperatura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TensionArterial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExamenesFisicos");
                });

            modelBuilder.Entity("AdSanare.Entities.Ingreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alergias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesMedicos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesQuirurgicos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<bool>("Defuncion")
                        .HasColumnType("bit");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEgreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicacionHabitual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Talla")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("AdSanare.Entities.ObraSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ObrasSociales");
                });

            modelBuilder.Entity("AdSanare.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DomicilioId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObraSocialId")
                        .HasColumnType("int");

                    b.Property<string>("ObraSocialNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.HasIndex("ObraSocialId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("AdSanare.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BajaLogica")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("AdSanare.Entities.Cama", b =>
                {
                    b.HasOne("AdSanare.Entities.Servicio", "ServicioInternacion")
                        .WithMany()
                        .HasForeignKey("ServicioInternacionId");
                });

            modelBuilder.Entity("AdSanare.Entities.Evolucion", b =>
                {
                    b.HasOne("AdSanare.Entities.Cama", "CamaInternacion")
                        .WithMany()
                        .HasForeignKey("CamaInternacionId");

                    b.HasOne("AdSanare.Entities.ExamenFisico", "ExamenFisico")
                        .WithMany()
                        .HasForeignKey("ExamenFisicoId");

                    b.HasOne("AdSanare.Entities.Ingreso", "Ingreso")
                        .WithMany()
                        .HasForeignKey("IngresoId");

                    b.HasOne("AdSanare.Entities.Servicio", "ServicioInternacion")
                        .WithMany()
                        .HasForeignKey("ServicioInternacionId");
                });

            modelBuilder.Entity("AdSanare.Entities.ExamenComplementario", b =>
                {
                    b.HasOne("AdSanare.Entities.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("AdSanare.Entities.Ingreso", b =>
                {
                    b.HasOne("AdSanare.Entities.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("AdSanare.Entities.Paciente", b =>
                {
                    b.HasOne("AdSanare.Entities.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioId");

                    b.HasOne("AdSanare.Entities.ObraSocial", "ObraSocial")
                        .WithMany()
                        .HasForeignKey("ObraSocialId");
                });
#pragma warning restore 612, 618
        }
    }
}
