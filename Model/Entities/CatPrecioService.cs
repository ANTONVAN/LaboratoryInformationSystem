using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class CatPrecioService : ICatPrecioService
	{
		public AppDataContext _context { get; set; }
		public CatPrecioService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<CatPrecio> GetAll()
		{
			return _context.CatPrecios.ToList();
		}

		public List<CatPrecio> GetByName(string prName)
		{
			var linq = from catPrecios in _context.CatPrecios.Include(m => m.ListaPrecios) select catPrecios;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}
		public List<CatPrecio> GetByKey(string prKey)
		{
			var linq = from catPrecios in _context.CatPrecios select catPrecios;
			if (!string.IsNullOrWhiteSpace(prKey))
				linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
			return linq.ToList();
		}

		public CatPrecio Save(CatPrecio prPrecio)
		{
			_context.CatPrecios.Add(prPrecio);
			_context.SaveChanges();
			return prPrecio;
		}

		public CatPrecio Update(CatPrecio prPrecio)
		{
			CatPrecio lPrecioFromDB = _context.CatPrecios.First(x => x.Id == prPrecio.Id);
			_context.Entry(lPrecioFromDB).CurrentValues.SetValues(prPrecio);
			_context.SaveChanges();
			return prPrecio;
		}

		public void Delete(CatPrecio prPrecio)
		{
			_context.Entry(prPrecio).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
