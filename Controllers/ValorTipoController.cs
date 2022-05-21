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
    public class ValorTipoController : ControllerBase
    {
        private readonly IValorTipoService _IValorTipoService;

        public ValorTipoController(IValorTipoService prIValorTipoService)
        {
            _IValorTipoService = prIValorTipoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ValorTipo> lResult = _IValorTipoService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prValorTipo)
        {
            List<ValorTipo> lResult = _IValorTipoService.GetByName(prValorTipo);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(ValorTipo prValorTipo)
        {
            return Ok(_IValorTipoService.Update(prValorTipo));
        }

        [HttpPost]
        public IActionResult Create(ValorTipo prValorTipo)
        {
            return Ok(_IValorTipoService.Save(prValorTipo));
        }

        [HttpDelete]
        public IActionResult Delete(ValorTipo prValorTipo)
        {
            _IValorTipoService.Delete(prValorTipo);
            return Ok();
        }
    }
}
