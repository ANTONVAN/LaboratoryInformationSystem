using ILab.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _IDepartamentoService;

        public DepartamentoController(IDepartamentoService prIDepartamentoService)
        {
            _IDepartamentoService = prIDepartamentoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Departamento> lResult = _IDepartamentoService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prDepartamento)
        {
            List<Departamento> lResult = _IDepartamentoService.GetByName(prDepartamento);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Departamento prDepartamento)
        {
            return Ok(_IDepartamentoService.Update(prDepartamento));
        }

        [HttpPost]
        public IActionResult Create(Departamento prDepartamento)
        {
            Console.WriteLine(prDepartamento);
            return Ok(_IDepartamentoService.Save(prDepartamento));
        }

        [HttpDelete]
        public IActionResult Delete(Departamento prDepartamento)
        {
            _IDepartamentoService.Delete(prDepartamento);
            return Ok();
        }
    }
}
