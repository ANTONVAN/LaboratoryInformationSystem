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
	public class MedicoController : ControllerBase
	{
    private readonly IMedicoService _IMedicoService;

    public MedicoController(IMedicoService prIMedicoService)
    {
      _IMedicoService = prIMedicoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Medico> lResult = _IMedicoService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult SearchByKey(string prMedico)
    {
      List<Medico> lResult = _IMedicoService.GetByKey(prMedico);
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(string prMedico)
    {
      List<Medico> lResult = _IMedicoService.GetByName(prMedico);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Medico prMedico)
    {
      return Ok(_IMedicoService.Update(prMedico));
    }

    [HttpPost]
    public IActionResult Create(Medico prMedico)
    {
      Console.WriteLine(prMedico);
      return Ok(_IMedicoService.Save(prMedico));
    }

    [HttpDelete]
    public IActionResult Delete(Medico prMedico)
    {
      _IMedicoService.Delete(prMedico);
      return Ok();
    }
  }
}
