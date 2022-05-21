using ILab.DependencyInjection;
using ILab.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IConsoleWriter _IConsoleWriter;
        private IDepartamentoService _IDepartamentoService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConsoleWriter prIConsoleWriter, IDepartamentoService prIDepartamentoService)
        {
            _logger = logger;
            _IConsoleWriter = prIConsoleWriter;
            _IDepartamentoService = prIDepartamentoService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //Dependency Injection
            //IConsoleWriter.Write();

            /*GET LIBRARY*/
            //List<Departamento> Departamentos = _IDepartamentoService.GetAll();
            //List<Departamento> lDepartamentos = _IDepartamentoService.GetByName("LABORATORIO");


            /*ADD DEPARTAMENTO*/
            //Departamento lNewDepartamento = new Departamento(){ Name="BANCO DE SANGRE"};
            //_IDepartamentoService.Save(lNewDepartamento);

            /*UPDATE DEPARTAMENTO*/
            //Departamento lDepartamentoToUpdate = _IDepartamentoService.GetByName("BANCO DE SANGRE").FirstOrDefault();
            //lDepartamentoToUpdate.Name = "Test departamento updated";
            //_IDepartamentoService.Update(lDepartamentoToUpdate);

            /*DELETE DEPARTAMENTO*/
            //Departamento lDepartamentoToDelete = _IDepartamentoService.GetByName("Test departamento updated").FirstOrDefault();
            //_IDepartamentoService.Delete(lDepartamentoToDelete);

            var rng = new Random();
            _IConsoleWriter.Write();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
