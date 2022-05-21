using ILab.Model;
using ILab.Model.Entities;
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
    public class ParametroController : ControllerBase
    {
        private readonly IParametroService _IParametroService;

        public ParametroController(IParametroService prIParametroService)
        {
            _IParametroService = prIParametroService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Parametro> lResult = _IParametroService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prParametro)
        {
            List<Parametro> lResult = _IParametroService.GetByName(prParametro);
            return Ok(lResult);
        }
        [HttpGet]
        public IActionResult SearchByKey(string prParametro)
        {
          List<Parametro> lResult = _IParametroService.GetByKey(prParametro);
          return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Parametro prParametro)
        {
            return Ok(_IParametroService.Update(prParametro));
        }

        [HttpPost]
        public IActionResult Create(Parametro prParametro)
        {
            return Ok(_IParametroService.Save(prParametro));
        }

        [HttpDelete]
        public IActionResult Delete(Parametro prParametro)
        {
            _IParametroService.Delete(prParametro);
            return Ok();
        }
    }
}
