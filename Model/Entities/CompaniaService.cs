using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class CompaniaService : ICompaniaService
	{
		public AppDataContext _context { get; set; }
		public CompaniaService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Compania> GetAll()
		{
			return _context.Companias.ToList();
		}

		public List<Compania> GetByName(string prName)
		{
			var linq = from areas in _context.Companias select areas;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}
		public List<Compania> GetByKey(string prKey)
		{
			var linq = from companias in _context.Companias.Include("CatPrecio") select companias;
			if (!string.IsNullOrWhiteSpace(prKey))
				linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
			return linq.ToList();
		}
		public Compania Save(Compania prCompania)
		{
			_context.Companias.Add(prCompania);
			_context.SaveChanges();
			return prCompania;
		}

		public Compania Update(Compania prCompania)
		{
			Compania lCompaniaFromDB = _context.Companias.First(x => x.Id == prCompania.Id);
			_context.Entry(lCompaniaFromDB).CurrentValues.SetValues(prCompania);
			_context.SaveChanges();
			return prCompania;
		}

		public void Delete(Compania prCompania)
		{
			_context.Entry(prCompania).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
