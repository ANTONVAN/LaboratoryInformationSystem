using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class SucursalService : ISucursalService
	{
		public AppDataContext _context { get; set; }
		public SucursalService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Sucursal> GetAll()
		{
			return _context.Sucursales.ToList();
		}

		public List<Sucursal> GetByName(string prName)
		{
			var linq = from areas in _context.Sucursales select areas;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}
		public List<Sucursal> GetByKey(string prKey)
		{
			var linq = from sucursales in _context.Sucursales select sucursales;
			if (!string.IsNullOrWhiteSpace(prKey))
				linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
			return linq.ToList();
		}
		public Sucursal Save(Sucursal prSucursal)
		{
			_context.Sucursales.Add(prSucursal);
			_context.SaveChanges();
			return prSucursal;
		}

		public Sucursal Update(Sucursal prSucursal)
		{
			Sucursal lSucursalFromDB = _context.Sucursales.First(x => x.Id == prSucursal.Id);
			_context.Entry(lSucursalFromDB).CurrentValues.SetValues(prSucursal);
			_context.SaveChanges();
			return prSucursal;
		}

		public void Delete(Sucursal prSucursal)
		{
			_context.Entry(prSucursal).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
