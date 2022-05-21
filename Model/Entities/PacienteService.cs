using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class PacienteService : IPacienteService
	{
		public AppDataContext _context { get; set; }
		public PacienteService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Paciente> GetAll()
		{
			return _context.Pacientes.Include(m => m.Solicitudes).ToList();
		}

		public List<Paciente> GetByName(string prName)
		{
			var linq = from pacientes in _context.Pacientes.Include(m => m.Solicitudes) select pacientes;
			if (!string.IsNullOrWhiteSpace(prName))
				linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
			return linq.ToList();
		}

		public List<Paciente> GetById(int prId)
		{
			var linq = from pacientes in _context.Pacientes.Include(m => m.Solicitudes) select pacientes;
			linq = linq.Where(x => x.Id == prId);
			return linq.ToList();
		}

		public Paciente Save(Paciente prPaciente)
		{
			_context.Pacientes.Add(prPaciente);
			_context.SaveChanges();
			return prPaciente;
		}

		public Paciente Update(Paciente prPaciente)
		{
			Paciente lPacienteFromDB = _context.Pacientes.Include(m => m.Solicitudes).First(x => x.Id == prPaciente.Id);
			_context.Entry(lPacienteFromDB).CurrentValues.SetValues(prPaciente);

			_context.SaveChanges();
			return prPaciente;
		}

		public void Delete(Paciente prPaciente)
		{
			_context.Entry(prPaciente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
