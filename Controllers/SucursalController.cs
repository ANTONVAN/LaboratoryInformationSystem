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
	public class SucursalController : ControllerBase
	{
    private readonly ISucursalService _ISucursalService;

    public SucursalController(ISucursalService prISucursalService)
    {
      _ISucursalService = prISucursalService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<Sucursal> lResult = _ISucursalService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(string prSucursal)
    {
      List<Sucursal> lResult = _ISucursalService.GetByName(prSucursal);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(Sucursal prSucursal)
    {
      return Ok(_ISucursalService.Update(prSucursal));
    }

    [HttpPost]
    public IActionResult Create(Sucursal prSucursal)
    {
      Console.WriteLine(prSucursal);
      return Ok(_ISucursalService.Save(prSucursal));
    }

    [HttpDelete]
    public IActionResult Delete(Sucursal prSucursal)
    {
      _ISucursalService.Delete(prSucursal);
      return Ok();
    }
  }
}
