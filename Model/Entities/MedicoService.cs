using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class MedicoService : IMedicoService
	{
		public AppDataContext _context { get; set; }
		public MedicoService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Medico> GetAll()
		{
			return _context.Medicos.ToList();
		}

		public List<Medico> GetByName(string prName)
		{
			var linq = from areas in _context.Medicos select areas;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}
		public List<Medico> GetByKey(string prKey)
		{
			var linq = from medicos in _context.Medicos select medicos;
			if (!string.IsNullOrWhiteSpace(prKey))
				linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
			return linq.ToList();
		}
		public Medico Save(Medico prMedico)
		{
			_context.Medicos.Add(prMedico);
			_context.SaveChanges();
			return prMedico;
		}

		public Medico Update(Medico prMedico)
		{
			Medico lMedicoFromDB = _context.Medicos.First(x => x.Id == prMedico.Id);
			_context.Entry(lMedicoFromDB).CurrentValues.SetValues(prMedico);
			_context.SaveChanges();
			return prMedico;
		}

		public void Delete(Medico prMedico)
		{
			_context.Entry(prMedico).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
