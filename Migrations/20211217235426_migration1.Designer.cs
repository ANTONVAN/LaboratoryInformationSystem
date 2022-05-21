﻿// <auto-generated />
using System;
using ILab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ILab.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20211217235426_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstudioEtiqueta", b =>
                {
                    b.Property<int>("EstudiosId")
                        .HasColumnType("int");

                    b.Property<int>("EtiquetasId")
                        .HasColumnType("int");

                    b.HasKey("EstudiosId", "EtiquetasId");

                    b.HasIndex("EtiquetasId");

                    b.ToTable("EstudioEtiqueta");
                });

            modelBuilder.Entity("EstudioIndicaciones", b =>
                {
                    b.Property<int>("EstudiosId")
                        .HasColumnType("int");

                    b.Property<int>("IndicacionesId")
                        .HasColumnType("int");

                    b.HasKey("EstudiosId", "IndicacionesId");

                    b.HasIndex("IndicacionesId");

                    b.ToTable("EstudioIndicaciones");
                });

            modelBuilder.Entity("EstudioPaquete", b =>
                {
                    b.Property<int>("EstudiosId")
                        .HasColumnType("int");

                    b.Property<int>("PaquetesId")
                        .HasColumnType("int");

                    b.HasKey("EstudiosId", "PaquetesId");

                    b.HasIndex("PaquetesId");

                    b.ToTable("EstudioPaquete");
                });

            modelBuilder.Entity("EstudioParametro", b =>
                {
                    b.Property<int>("EstudiosId")
                        .HasColumnType("int");

                    b.Property<int>("ParametrosId")
                        .HasColumnType("int");

                    b.HasKey("EstudiosId", "ParametrosId");

                    b.HasIndex("ParametrosId");

                    b.ToTable("EstudioParametro");
                });

            modelBuilder.Entity("ILab.Model.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("departamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("departamentoId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ILab.Model.CatPrecio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatPrecios");
                });

            modelBuilder.Entity("ILab.Model.Compania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CP")
                        .HasColumnType("int");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreComercial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<int>("catPrecioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("catPrecioId");

                    b.ToTable("Companias");
                });

            modelBuilder.Entity("ILab.Model.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ILab.Model.Estudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("areaId")
                        .HasColumnType("int");

                    b.Property<int>("maquiladorId")
                        .HasColumnType("int");

                    b.Property<int>("metodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("areaId");

                    b.HasIndex("maquiladorId");

                    b.HasIndex("metodoId");

                    b.ToTable("Estudios");
                });

            modelBuilder.Entity("ILab.Model.EstudioSol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstudioId")
                        .HasColumnType("int");

                    b.Property<int?>("SolicitudId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudioId");

                    b.HasIndex("SolicitudId");

                    b.ToTable("EstudioSols");
                });

            modelBuilder.Entity("ILab.Model.Etiqueta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("ILab.Model.Indicaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Indicaciones");
                });

            modelBuilder.Entity("ILab.Model.ListaPrecio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("catPrecioId")
                        .HasColumnType("int");

                    b.Property<int>("estudioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("catPrecioId");

                    b.HasIndex("estudioId");

                    b.ToTable("ListaPrecios");
                });

            modelBuilder.Entity("ILab.Model.Maquilador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maquiladores");
                });

            modelBuilder.Entity("ILab.Model.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CP")
                        .HasColumnType("int");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Colonia")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroExterior")
                        .HasColumnType("int");

                    b.Property<int>("NumeroInterior")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ILab.Model.Metodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Metodos");
                });

            modelBuilder.Entity("ILab.Model.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CP")
                        .HasColumnType("int");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ILab.Model.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("ILab.Model.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valorTipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("valorTipoId");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("ILab.Model.Reactivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reactivos");
                });

            modelBuilder.Entity("ILab.Model.Resultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstudioSolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudioSolId");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("ILab.Model.Solicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cargo")
                        .HasColumnType("float");

                    b.Property<string>("Compania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Medico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("ILab.Model.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CP")
                        .HasColumnType("int");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Colonia")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroExterior")
                        .HasColumnType("int");

                    b.Property<int>("NumeroInterior")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("ILab.Model.ValorReferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad1")
                        .HasColumnType("int");

                    b.Property<int>("Edad2")
                        .HasColumnType("int");

                    b.Property<string>("Multiple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor1")
                        .HasColumnType("int");

                    b.Property<int>("Valor2")
                        .HasColumnType("int");

                    b.Property<int>("parametroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parametroId");

                    b.ToTable("ValorReferencias");
                });

            modelBuilder.Entity("ILab.Model.ValorTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValorTipos");
                });

            modelBuilder.Entity("ParametroReactivo", b =>
                {
                    b.Property<int>("ParametrosId")
                        .HasColumnType("int");

                    b.Property<int>("ReactivosId")
                        .HasColumnType("int");

                    b.HasKey("ParametrosId", "ReactivosId");

                    b.HasIndex("ReactivosId");

                    b.ToTable("ParametroReactivo");
                });

            modelBuilder.Entity("EstudioEtiqueta", b =>
                {
                    b.HasOne("ILab.Model.Estudio", null)
                        .WithMany()
                        .HasForeignKey("EstudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Etiqueta", null)
                        .WithMany()
                        .HasForeignKey("EtiquetasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstudioIndicaciones", b =>
                {
                    b.HasOne("ILab.Model.Estudio", null)
                        .WithMany()
                        .HasForeignKey("EstudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Indicaciones", null)
                        .WithMany()
                        .HasForeignKey("IndicacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstudioPaquete", b =>
                {
                    b.HasOne("ILab.Model.Estudio", null)
                        .WithMany()
                        .HasForeignKey("EstudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Paquete", null)
                        .WithMany()
                        .HasForeignKey("PaquetesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstudioParametro", b =>
                {
                    b.HasOne("ILab.Model.Estudio", null)
                        .WithMany()
                        .HasForeignKey("EstudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Parametro", null)
                        .WithMany()
                        .HasForeignKey("ParametrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ILab.Model.Area", b =>
                {
                    b.HasOne("ILab.Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("departamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ILab.Model.Compania", b =>
                {
                    b.HasOne("ILab.Model.CatPrecio", "CatPrecio")
                        .WithMany("Companias")
                        .HasForeignKey("catPrecioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatPrecio");
                });

            modelBuilder.Entity("ILab.Model.Estudio", b =>
                {
                    b.HasOne("ILab.Model.Area", "Area")
                        .WithMany()
                        .HasForeignKey("areaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Maquilador", "Maquilador")
                        .WithMany("Estudios")
                        .HasForeignKey("maquiladorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Metodo", "Metodo")
                        .WithMany("Estudios")
                        .HasForeignKey("metodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Maquilador");

                    b.Navigation("Metodo");
                });

            modelBuilder.Entity("ILab.Model.EstudioSol", b =>
                {
                    b.HasOne("ILab.Model.Estudio", "Estudio")
                        .WithMany()
                        .HasForeignKey("EstudioId");

                    b.HasOne("ILab.Model.Solicitud", "Solicitud")
                        .WithMany("EstudioSols")
                        .HasForeignKey("SolicitudId");

                    b.Navigation("Estudio");

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("ILab.Model.ListaPrecio", b =>
                {
                    b.HasOne("ILab.Model.CatPrecio", "CatPrecios")
                        .WithMany("ListaPrecios")
                        .HasForeignKey("catPrecioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Estudio", "Estudio")
                        .WithMany()
                        .HasForeignKey("estudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatPrecios");

                    b.Navigation("Estudio");
                });

            modelBuilder.Entity("ILab.Model.Parametro", b =>
                {
                    b.HasOne("ILab.Model.ValorTipo", "ValorTipo")
                        .WithMany()
                        .HasForeignKey("valorTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValorTipo");
                });

            modelBuilder.Entity("ILab.Model.Resultado", b =>
                {
                    b.HasOne("ILab.Model.EstudioSol", "EstudioSol")
                        .WithMany("Resultados")
                        .HasForeignKey("EstudioSolId");

                    b.Navigation("EstudioSol");
                });

            modelBuilder.Entity("ILab.Model.Solicitud", b =>
                {
                    b.HasOne("ILab.Model.Paciente", "Paciente")
                        .WithMany("Solicitudes")
                        .HasForeignKey("PacienteId");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ILab.Model.ValorReferencia", b =>
                {
                    b.HasOne("ILab.Model.Parametro", "Parametro")
                        .WithMany("ValorReferencias")
                        .HasForeignKey("parametroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parametro");
                });

            modelBuilder.Entity("ParametroReactivo", b =>
                {
                    b.HasOne("ILab.Model.Parametro", null)
                        .WithMany()
                        .HasForeignKey("ParametrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILab.Model.Reactivo", null)
                        .WithMany()
                        .HasForeignKey("ReactivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ILab.Model.CatPrecio", b =>
                {
                    b.Navigation("Companias");

                    b.Navigation("ListaPrecios");
                });

            modelBuilder.Entity("ILab.Model.EstudioSol", b =>
                {
                    b.Navigation("Resultados");
                });

            modelBuilder.Entity("ILab.Model.Maquilador", b =>
                {
                    b.Navigation("Estudios");
                });

            modelBuilder.Entity("ILab.Model.Metodo", b =>
                {
                    b.Navigation("Estudios");
                });

            modelBuilder.Entity("ILab.Model.Paciente", b =>
                {
                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("ILab.Model.Parametro", b =>
                {
                    b.Navigation("ValorReferencias");
                });

            modelBuilder.Entity("ILab.Model.Solicitud", b =>
                {
                    b.Navigation("EstudioSols");
                });
#pragma warning restore 612, 618
        }
    }
}
