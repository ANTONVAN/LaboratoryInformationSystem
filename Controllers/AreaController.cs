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
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _IAreaService;

        public AreaController(IAreaService prIAreaService)
        {
            _IAreaService = prIAreaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Area> lResult = _IAreaService.GetAll();
            return Ok(lResult);
        }

        [HttpGet]
        public IActionResult Search(string prArea)
        {
            List<Area> lResult = _IAreaService.GetByName(prArea);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(Area prArea)
        {
            return Ok(_IAreaService.Update(prArea));
        }

        [HttpPost]
        public IActionResult Create(Area prArea)
        {
            Console.WriteLine(prArea);
            return Ok(_IAreaService.Save(prArea));
        }

        [HttpDelete]
        public IActionResult Delete(Area prArea)
        {
            _IAreaService.Delete(prArea);
            return Ok();
        }
    }
}
