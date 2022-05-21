using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class ResultadoService : IResultadoService
	{
		public AppDataContext _context { get; set; }
		public ResultadoService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<Resultado> GetAll()
		{
			return _context.Resultados.ToList();
		}

		public List<Resultado> GetById(int prId)
		{
			var linq = from pacientes in _context.Resultados select pacientes;
			linq = linq.Where(x => x.Id == prId);
			return linq.ToList();
		}

		public Resultado Save(Resultado prResultado)
		{
			_context.Resultados.Add(prResultado);
			_context.SaveChanges();
			return prResultado;
		}

		public Resultado Update(Resultado prResultado)
		{
			Resultado lResultadoFromDB = _context.Resultados.First(x => x.Id == prResultado.Id);
			_context.Entry(lResultadoFromDB).CurrentValues.SetValues(prResultado);

			_context.SaveChanges();
			return prResultado;
		}

		public void Delete(Resultado prResultado)
		{
			_context.Entry(prResultado).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
