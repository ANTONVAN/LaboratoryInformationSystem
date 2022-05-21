using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class PaqueteService : IPaqueteService
	{
		public AppDataContext _context { get; set; }

		public PaqueteService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Paquete> GetAll()
		{
			return _context.Paquetes.ToList();
		}

		public List<Paquete> GetByName(string prName)
		{
			//.Include("Area").Include("Maquilador").Include("Metodo")
			var linq = from paquetes in _context.Paquetes.Include("Estudios") select paquetes;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}

		public Paquete Save(Paquete prPaquete)
		{
			_context.Paquetes.Add(prPaquete);
			_context.SaveChanges();
			return prPaquete;
		}

		public Paquete Update(Paquete prPaquete)
		{

			Paquete lPaqueteFromDB = _context.Paquetes.Include("Estudios").First(x => x.Id == prPaquete.Id);
			_context.Entry(lPaqueteFromDB).CurrentValues.SetValues(prPaquete);

			if (prPaquete.Estudios != null)
			{
				Estudio lEstudioFromDB = _context.Estudios.First(x => x.Id == prPaquete.Estudios.First().Id);
				lPaqueteFromDB.Estudios.Add(lEstudioFromDB);
			}

			_context.SaveChanges();
			return prPaquete;
		}

		public void Delete(Paquete prPaquete)
		{
			_context.Entry(prPaquete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
