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
	public class EstudioSolController : ControllerBase
	{
    private readonly IEstudioSolService _IEstudioSolService;

    public EstudioSolController(IEstudioSolService prIEstudioSolService)
    {
      _IEstudioSolService = prIEstudioSolService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<EstudioSol> lResult = _IEstudioSolService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult SearchByKey(int prEstudioSol)
    {
      List<EstudioSol> lResult = _IEstudioSolService.GetById(prEstudioSol);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(EstudioSol prEstudioSol)
    {
      return Ok(_IEstudioSolService.Update(prEstudioSol));
    }

    [HttpPost]
    public IActionResult Create(EstudioSol prEstudioSol)
    {
      return Ok(_IEstudioSolService.Save(prEstudioSol));
    }

    [HttpDelete]
    public IActionResult Delete(EstudioSol prEstudioSol)
    {
      _IEstudioSolService.Delete(prEstudioSol);
      return Ok();
    }
  }
}
