using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class EstudioSolService : IEstudioSolService
	{
		public AppDataContext _context { get; set; }
		public EstudioSolService(AppDataContext prAppDataContext)
		{
			_context = prAppDataContext;
		}

		public List<EstudioSol> GetAll()
		{
			return _context.EstudioSols.Include(m => m.Resultados).ToList();
		}

		public List<EstudioSol> GetById(int prId)
		{
			var linq = from estudiosSols in _context.EstudioSols.Include(m => m.Resultados) select estudiosSols;
			linq = linq.Where(x => x.Id == prId);
			return linq.ToList();
		}

		public EstudioSol Save(EstudioSol prEstudioSol)
		{
			_context.EstudioSols.Add(prEstudioSol);
			_context.SaveChanges();
			return prEstudioSol;
		}

		public EstudioSol Update(EstudioSol prEstudioSol)
		{
			EstudioSol lEstudioSolFromDB = _context.EstudioSols.Include(m => m.Resultados).First(x => x.Id == prEstudioSol.Id);
			_context.Entry(lEstudioSolFromDB).CurrentValues.SetValues(prEstudioSol);

			_context.SaveChanges();
			return prEstudioSol;
		}

		public void Delete(EstudioSol prEstudioSol)
		{
			_context.Entry(prEstudioSol).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			_context.SaveChanges();
		}
	}
}
