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
    public class EtiquetaController : ControllerBase
    {
        private readonly IEtiquetaService _IEtiquetaService;

        public EtiquetaController(IEtiquetaService prIEtiquetaService)
        {
            _IEtiquetaService = prIEtiquetaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Etiqueta> lResult = _IEtiquetaService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prEtiqueta)
        {
            List<Etiqueta> lResult = _IEtiquetaService.GetByName(prEtiqueta);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Etiqueta prEtiqueta)
        {
            return Ok(_IEtiquetaService.Update(prEtiqueta));
        }

        [HttpPost]
        public IActionResult Create(Etiqueta prEtiqueta)
        {
            return Ok(_IEtiquetaService.Save(prEtiqueta));
        }

        [HttpDelete]
        public IActionResult Delete(Etiqueta prEtiqueta)
        {
            _IEtiquetaService.Delete(prEtiqueta);
            return Ok();
        }
    }
}
