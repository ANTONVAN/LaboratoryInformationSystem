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
	public class ReactivoController : ControllerBase
	{
    private readonly IReactivoService _IReactivoService;

    public ReactivoController(IReactivoService prIReactivoService)
    {
      _IReactivoService = prIReactivoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Reactivo> lResult = _IReactivoService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(string prReactivo)
    {
      List<Reactivo> lResult = _IReactivoService.GetByName(prReactivo);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Reactivo prReactivo)
    {
      return Ok(_IReactivoService.Update(prReactivo));
    }

    [HttpPost]
    public IActionResult Create(Reactivo prReactivo)
    {
      Console.WriteLine(prReactivo);
      return Ok(_IReactivoService.Save(prReactivo));
    }

    [HttpDelete]
    public IActionResult Delete(Reactivo prReactivo)
    {
      _IReactivoService.Delete(prReactivo);
      return Ok();
    }
  }
}
