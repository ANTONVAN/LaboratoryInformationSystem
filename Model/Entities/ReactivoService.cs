using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class ReactivoService : IReactivoService
	{
		public AppDataContext _context { get; set; }

		public ReactivoService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Reactivo> GetAll()
		{
			return _context.Reactivos.ToList();
		}

		public List<Reactivo> GetByName(string prName)
		{
			//.Include("Area").Include("Maquilador").Include("Metodo")
			var linq = from reactivos in _context.Reactivos select reactivos;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}

		public Reactivo Save(Reactivo prReactivo)
		{
			_context.Reactivos.Add(prReactivo);
			_context.SaveChanges();
			return prReactivo;
		}

		public Reactivo Update(Reactivo prReactivo)
		{

			Reactivo lReactivoFromDB = _context.Reactivos.First(x => x.Id == prReactivo.Id);
			_context.Entry(lReactivoFromDB).CurrentValues.SetValues(prReactivo);
			_context.SaveChanges();
			return prReactivo;
		}

		public void Delete(Reactivo prReactivo)
		{
			_context.Entry(prReactivo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
