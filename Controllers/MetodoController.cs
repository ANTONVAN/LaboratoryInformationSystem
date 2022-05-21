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
    public class MetodoController : ControllerBase
    {
        private readonly IMetodoService _IMetodoService;

        public MetodoController(IMetodoService prIMetodoService)
        {
            _IMetodoService = prIMetodoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Metodo> lResult = _IMetodoService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prMetodo)
        {
            List<Metodo> lResult = _IMetodoService.GetByName(prMetodo);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Metodo prMetodo)
        {
            return Ok(_IMetodoService.Update(prMetodo));
        }

        [HttpPost]
        public IActionResult Create(Metodo prMetodo)
        {
            return Ok(_IMetodoService.Save(prMetodo));
        }

        [HttpDelete]
        public IActionResult Delete(Metodo prMetodo)
        {
            _IMetodoService.Delete(prMetodo);
            return Ok();
        }
    }
}
