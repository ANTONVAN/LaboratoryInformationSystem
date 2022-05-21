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
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioService _IEstudioService;

        public EstudioController(IEstudioService prIEstudioService)
        {
            _IEstudioService = prIEstudioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Estudio> lResult = _IEstudioService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prEstudio)
        {
            List<Estudio> lResult = _IEstudioService.GetByName(prEstudio);
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult SearchByKey(string prEstudio)
        {
          List<Estudio> lResult = _IEstudioService.GetByKey(prEstudio);
          return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Estudio prEstudio)
        {
            return Ok(_IEstudioService.Update(prEstudio));
        }   


        [HttpPost]
        public IActionResult Create(Estudio prEstudio)
        {
            return Ok(_IEstudioService.Save(prEstudio));
        }

        [HttpDelete]
        public IActionResult Delete(Estudio prEstudio)
        {
            _IEstudioService.Delete(prEstudio);
            return Ok();
        }
    }
}
