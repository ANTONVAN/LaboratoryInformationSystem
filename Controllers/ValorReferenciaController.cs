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
    public class ValorReferenciaController : ControllerBase
    {
        private readonly IValorReferenciaService _IValorReferenciaService;

        public ValorReferenciaController(IValorReferenciaService prIValorReferenciaService)
        {
            _IValorReferenciaService = prIValorReferenciaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ValorReferencia> lResult = _IValorReferenciaService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prValorReferencia)
        {
            List<ValorReferencia> lResult = _IValorReferenciaService.GetByName(prValorReferencia);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(ValorReferencia prValorReferencia)
        {
            return Ok(_IValorReferenciaService.Update(prValorReferencia));
        }

        [HttpPost]
        public IActionResult Create(ValorReferencia prValorReferencia)
        {
            return Ok(_IValorReferenciaService.Save(prValorReferencia));
        }

        [HttpDelete]
        public IActionResult Delete(ValorReferencia prValorReferencia)
        {
            _IValorReferenciaService.Delete(prValorReferencia);
            return Ok();
        }
    }
}
