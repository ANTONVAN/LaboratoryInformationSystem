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
	public class SolicitudController : ControllerBase
	{
    private readonly ISolicitudService _ISolicitudService;

    public SolicitudController(ISolicitudService prISolicitudService)
    {
      _ISolicitudService = prISolicitudService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Solicitud> lResult = _ISolicitudService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(int prSolicitud)
    {
      List<Solicitud> lResult = _ISolicitudService.GetById(prSolicitud);
      return Ok(lResult);
    }
    [HttpGet]
    public IActionResult SearchByKey(int prSolicitud)
    {
      List<Solicitud> lResult = _ISolicitudService.GetById(prSolicitud);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Solicitud prSolicitud)
    {
      return Ok(_ISolicitudService.Update(prSolicitud));
    }

    [HttpPost]
    public IActionResult Create(Solicitud prSolicitud)
    {
      return Ok(_ISolicitudService.Save(prSolicitud));
    }

    [HttpDelete]
    public IActionResult Delete(Solicitud prSolicitud)
    {
      _ISolicitudService.Delete(prSolicitud);
      return Ok();
    }
  }
}
