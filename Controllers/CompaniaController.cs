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
	public class CompaniaController : ControllerBase
	{
    private readonly ICompaniaService _ICompaniaService;

    public CompaniaController(ICompaniaService prICompaniaService)
    {
      _ICompaniaService = prICompaniaService;
    }

		[HttpGet]
		public IActionResult GetAll()
		{
			List<Compania> lResult = _ICompaniaService.GetAll();
			return Ok(lResult);
		}

		[HttpGet]
		public IActionResult Search(string prCompania)
		{
			List<Compania> lResult = _ICompaniaService.GetByName(prCompania);
			return Ok(lResult);
		}

    [HttpGet]
    public IActionResult SearchByKey(string prCompania)
    {
      List<Compania> lResult = _ICompaniaService.GetByKey(prCompania);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Compania prCompania)
    {
      return Ok(_ICompaniaService.Update(prCompania));
    }

    [HttpPost]
    public IActionResult Create(Compania prCompania)
    {
      Console.WriteLine(prCompania);
      return Ok(_ICompaniaService.Save(prCompania));
    }

    [HttpDelete]
    public IActionResult Delete(Compania prCompania)
    {
      _ICompaniaService.Delete(prCompania);
      return Ok();
    }
  }
}
