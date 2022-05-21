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
	public class PaqueteController : ControllerBase
	{
    private readonly IPaqueteService _IPaqueteService;

    public PaqueteController(IPaqueteService prIPaqueteService)
    {
      _IPaqueteService = prIPaqueteService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Paquete> lResult = _IPaqueteService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(string prPaquete)
    {
      List<Paquete> lResult = _IPaqueteService.GetByName(prPaquete);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Paquete prPaquete)
    {
      return Ok(_IPaqueteService.Update(prPaquete));
    }

    [HttpPost]
    public IActionResult Create(Paquete prPaquete)
    {
      Console.WriteLine(prPaquete);
      return Ok(_IPaqueteService.Save(prPaquete));
    }

    [HttpDelete]
    public IActionResult Delete(Paquete prPaquete)
    {
      _IPaqueteService.Delete(prPaquete);
      return Ok();
    }
  }
}
