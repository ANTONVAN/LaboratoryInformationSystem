using System.Collections.Generic;

namespace ILab.Model
{
	public interface IEstudioSolService
	{
		void Delete(EstudioSol prEstudioSol);
		List<EstudioSol> GetAll();
		List<EstudioSol> GetById(int prId);
		EstudioSol Save(EstudioSol prEstudioSol);
		EstudioSol Update(EstudioSol prEstudioSol);
	}
}