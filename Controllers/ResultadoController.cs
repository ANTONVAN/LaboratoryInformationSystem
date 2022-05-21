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
	public class ResultadoController : ControllerBase
	{
    private readonly IResultadoService _IResultadoService;

    public ResultadoController(IResultadoService prIResultadoService)
    {
      _IResultadoService = prIResultadoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Resultado> lResult = _IResultadoService.GetAll();
      return Ok(lResult);
    }


    [HttpGet]
    public IActionResult SearchByKey(int prResultado)
    {
      List<Resultado> lResult = _IResultadoService.GetById(prResultado);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Resultado prResultado)
    {
      return Ok(_IResultadoService.Update(prResultado));
    }

    [HttpPost]
    public IActionResult Create(Resultado prResultado)
    {
      return Ok(_IResultadoService.Save(prResultado));
    }

    [HttpDelete]
    public IActionResult Delete(Resultado prResultado)
    {
      _IResultadoService.Delete(prResultado);
      return Ok();
    }
  }
}
