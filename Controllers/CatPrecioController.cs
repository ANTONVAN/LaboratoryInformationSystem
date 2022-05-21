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
	public class CatPrecioController : ControllerBase
	{
    private readonly ICatPrecioService _ICatPrecioService;

    public CatPrecioController(ICatPrecioService prICatPrecioService)
    {
      _ICatPrecioService = prICatPrecioService;
    }

		[HttpGet]
		public IActionResult GetAll()
		{
			List<CatPrecio> lResult = _ICatPrecioService.GetAll();
			return Ok(lResult);
		}

		[HttpGet]
		public IActionResult Search(string prCatPrecio)
		{
			List<CatPrecio> lResult = _ICatPrecioService.GetByName(prCatPrecio);
			return Ok(lResult);
		}
		[HttpGet]
		public IActionResult SearchByKey(string prCatPrecio)
		{
			List<CatPrecio> lResult = _ICatPrecioService.GetByKey(prCatPrecio);
			return Ok(lResult);
		}

		[HttpPut]
    public IActionResult Update(CatPrecio prCatPrecio)
    {
      return Ok(_ICatPrecioService.Update(prCatPrecio));
    }

    [HttpPost]
    public IActionResult Create(CatPrecio prCatPrecio)
    {
      Console.WriteLine(prCatPrecio);
      return Ok(_ICatPrecioService.Save(prCatPrecio));
    }

    [HttpDelete]
    public IActionResult Delete(CatPrecio prCatPrecio)
    {
      _ICatPrecioService.Delete(prCatPrecio);
      return Ok();
    }
  }
}
