using ILab.CustomMiddleware;
using ILab.DependencyInjection;
using ILab.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using System.Text.Json.Serialization;

namespace ILab
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers().AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


      services.AddControllersWithViews();
      services.AddTransient<IConsoleWriter, ConsoleWriter>();
      services.AddTransient<ISucursalService, SucursalService>();
      services.AddTransient<IMedicoService, MedicoService>();
      services.AddTransient<IDepartamentoService, DepartamentoService>();
      services.AddTransient<IAreaService, AreaService>();
      services.AddTransient<IEstudioService, EstudioService>();
      services.AddTransient<IParametroService, ParametroService>();
      services.AddTransient<IIndicacionesService, IndicacionesService>();
      services.AddTransient<IMetodoService, MetodoService>();
      services.AddTransient<IEtiquetaService, EtiquetaService>();
      services.AddTransient<IMaquiladorService, MaquiladorService>();
      services.AddTransient<IValorTipoService, ValorTipoService>();
      services.AddTransient<IValorReferenciaService, ValorReferenciaService>();
      services.AddTransient<ICompaniaService, CompaniaService>();
      services.AddTransient<ICatPrecioService, CatPrecioService>();
      services.AddTransient<IListaPrecioService, ListaPrecioService>();
      services.AddTransient<IPacienteService, PacienteService>();
      services.AddTransient<ISolicitudService, SolicitudService>();
      services.AddTransient<IEstudioSolService, EstudioSolService>();
      services.AddTransient<IResultadoService, ResultadoService>();
      services.AddTransient<IPaqueteService, PaqueteService>();
      services.AddTransient<IReactivoService, ReactivoService>();
      //services.AddDbContext<AppDataContext>(x=>x.UseSqlServer("CONNECTION STRING"));
      services.AddDbContext<AppDataContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<AppDataContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ASP.NET CORE API", Version = "v1" });
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REACT ASP.NET");
            });
            app.UseRouting();
            app.UseMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
