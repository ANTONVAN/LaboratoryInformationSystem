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
	public class PacienteController : ControllerBase
	{
    private readonly IPacienteService _IPacienteService;

    public PacienteController(IPacienteService prIPacienteService)
    {
      _IPacienteService = prIPacienteService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Paciente> lResult = _IPacienteService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(string prPaciente)
    {
      List<Paciente> lResult = _IPacienteService.GetByName(prPaciente);
      return Ok(lResult);
    }
    [HttpGet]
    public IActionResult SearchByKey(int prPaciente)
    {
      List<Paciente> lResult = _IPacienteService.GetById(prPaciente);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Paciente prPaciente)
    {
      return Ok(_IPacienteService.Update(prPaciente));
    }

    [HttpPost]
    public IActionResult Create(Paciente prPaciente)
    {
      return Ok(_IPacienteService.Save(prPaciente));
    }

    [HttpDelete]
    public IActionResult Delete(Paciente prPaciente)
    {
      _IPacienteService.Delete(prPaciente);
      return Ok();
    }
  }
}
