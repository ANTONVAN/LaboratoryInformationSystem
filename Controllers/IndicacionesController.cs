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
    public class IndicacionesController : ControllerBase
    {
        private readonly IIndicacionesService _IIndicacionesService;

        public IndicacionesController(IIndicacionesService prIIndicacionesService)
        {
            _IIndicacionesService = prIIndicacionesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Indicaciones> lResult = _IIndicacionesService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prIndicaciones)
        {
            List<Indicaciones> lResult = _IIndicacionesService.GetByName(prIndicaciones);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Indicaciones prIndicaciones)
        {
            return Ok(_IIndicacionesService.Update(prIndicaciones));
        }

        [HttpPost]
        public IActionResult Create(Indicaciones prIndicaciones)
        {
            return Ok(_IIndicacionesService.Save(prIndicaciones));
        }

        [HttpDelete]
        public IActionResult Delete(Indicaciones prIndicaciones)
        {
            _IIndicacionesService.Delete(prIndicaciones);
            return Ok();
        }
    }
}
