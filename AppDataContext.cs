using ILab.Model;
using ILab.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppDataContext: DbContext
    {
       

        public AppDataContext(DbContextOptions<AppDataContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parametro>()
                .HasMany(c => c.ValorReferencias)
                .WithOne(e => e.Parametro);

            modelBuilder.Entity<CatPrecio>()
                .HasMany(c => c.Companias)
                .WithOne(e => e.CatPrecio);

            modelBuilder.Entity<CatPrecio>()
                .HasMany(c => c.ListaPrecios)
                .WithOne(e => e.CatPrecios);

            modelBuilder.Entity<Paciente>()
                .HasMany(c => c.Solicitudes)
                .WithOne(e => e.Paciente);

            modelBuilder.Entity<Solicitud>()
                .HasMany(c => c.EstudioSols)
                .WithOne(e => e.Solicitud);

            modelBuilder.Entity<EstudioSol>()
                .HasMany(c => c.Resultados)
                .WithOne(e => e.EstudioSol);

            


    }


        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Indicaciones> Indicaciones { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Metodo> Metodos { get; set; }
        public DbSet<Maquilador> Maquiladores { get; set; }
        public DbSet <ValorTipo> ValorTipos { get; set; }
        public DbSet<ValorReferencia> ValorReferencias { get; set; }
        public DbSet<Compania> Companias { get; set; }
        public DbSet<CatPrecio> CatPrecios { get; set; }
        public DbSet<ListaPrecio> ListaPrecios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<EstudioSol> EstudioSols { get; set; }
        public DbSet<Reactivo> Reactivos { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Medico> Medicos { get; set; }

  }

}
