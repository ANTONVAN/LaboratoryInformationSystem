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
    public class MaquiladorController : ControllerBase
    {
        private readonly IMaquiladorService _IMaquiladorService;

        public MaquiladorController(IMaquiladorService prIMaquiladorService)
        {
            _IMaquiladorService = prIMaquiladorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Maquilador> lResult = _IMaquiladorService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prMaquilador)
        {
            List<Maquilador> lResult = _IMaquiladorService.GetByName(prMaquilador);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Maquilador prMaquilador)
        {
            return Ok(_IMaquiladorService.Update(prMaquilador));
        }

        [HttpPost]
        public IActionResult Create(Maquilador prMaquilador)
        {
            return Ok(_IMaquiladorService.Save(prMaquilador));
        }

        [HttpDelete]
        public IActionResult Delete(Maquilador prMaquilador)
        {
            _IMaquiladorService.Delete(prMaquilador);
            return Ok();
        }
    }
}
