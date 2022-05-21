using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class SolicitudService : ISolicitudService
	{
		public AppDataContext _context { get; set; }
		public SolicitudService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Solicitud> GetAll()
		{
			return _context.Solicitudes.Include(m => m.EstudioSols).ToList();
		}

		public List<Solicitud> GetById(int prId)
		{
			var linq = from solicitudes in _context.Solicitudes.Include(m => m.EstudioSols) select solicitudes;
			linq = linq.Where(x => x.Id == prId);
			return linq.ToList();
		}

		public Solicitud Save(Solicitud prSolicitud)
		{
			_context.Solicitudes.Add(prSolicitud);
			_context.SaveChanges();
			return prSolicitud;
		}

		public Solicitud Update(Solicitud prSolicitud)
		{
			Solicitud lSolicitudFromDB = _context.Solicitudes.Include(m => m.EstudioSols).First(x => x.Id == prSolicitud.Id);
			_context.Entry(lSolicitudFromDB).CurrentValues.SetValues(prSolicitud);

			_context.SaveChanges();
			return prSolicitud;
		}

		public void Delete(Solicitud prSolicitud)
		{
			_context.Entry(prSolicitud).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
