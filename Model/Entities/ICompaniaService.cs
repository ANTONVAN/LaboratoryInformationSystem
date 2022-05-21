using System.Collections.Generic;

namespace ILab.Model
{
	public interface ICompaniaService
	{
		void Delete(Compania prCompania);
		List<Compania> GetAll();
		List<Compania> GetByKey(string prKey);
		List<Compania> GetByName(string prName);
		Compania Save(Compania prCompania);
		Compania Update(Compania prCompania);
	}
}