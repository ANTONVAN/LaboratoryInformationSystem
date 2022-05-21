using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class ListaPrecioService : IListaPrecioService
	{
		public AppDataContext _context { get; set; }
		public ListaPrecioService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<ListaPrecio> GetAll()
		{
			return _context.ListaPrecios.ToList();
		}

		public List<ListaPrecio> GetByEstudioAndCatPrecio(int prEstudioId, int prCatPrecioId)
		{
			var linq = from listaPrecios in _context.ListaPrecios select listaPrecios;
				linq = linq.Where(x => x.estudioId == prEstudioId).Where(x => x.catPrecioId == prCatPrecioId);
			return linq.ToList();
		}

		public ListaPrecio Save(ListaPrecio prPrecio)
		{
			_context.ListaPrecios.AddRange(prPrecio);
			_context.SaveChanges();
			return prPrecio;
		}

		public ListaPrecio Update(ListaPrecio prPrecio)
		{
			ListaPrecio lPrecioFromDB = _context.ListaPrecios.First(x => x.Id == prPrecio.Id);
			_context.Entry(lPrecioFromDB).CurrentValues.SetValues(prPrecio);
			_context.SaveChanges();
			return prPrecio;
		}

		public void Delete(ListaPrecio prPrecio)
		{
			_context.Entry(prPrecio).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
