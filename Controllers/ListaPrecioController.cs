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
	public class ListaPrecioController : ControllerBase
	{
    private readonly IListaPrecioService _IListaPrecioService;

    public ListaPrecioController(IListaPrecioService prIListaPrecioService)
    {
      _IListaPrecioService = prIListaPrecioService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      List<ListaPrecio> lResult = _IListaPrecioService.GetAll();
      return Ok(lResult);
    }

    [HttpGet]
    public IActionResult Search(int prEstudioId, int prCatPrecioId)
    {
      List<ListaPrecio> lResult = _IListaPrecioService.GetByEstudioAndCatPrecio(prEstudioId, prCatPrecioId);
      return Ok(lResult);
    }

    [HttpPut]
    public IActionResult Update(ListaPrecio prListaPrecio)
    {
      return Ok(_IListaPrecioService.Update(prListaPrecio));
    }

    [HttpPost]
    public IActionResult Create(ListaPrecio prListaPrecio)
    {
      Console.WriteLine(prListaPrecio);
      return Ok(_IListaPrecioService.Save(prListaPrecio));
    }

    [HttpDelete]
    public IActionResult Delete(ListaPrecio prListaPrecio)
    {
      _IListaPrecioService.Delete(prListaPrecio);
      return Ok();
    }
  }
}
