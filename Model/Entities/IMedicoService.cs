using System.Collections.Generic;

namespace ILab.Model
{
	public interface IMedicoService
	{
		void Delete(Medico prMedico);
		List<Medico> GetAll();
		List<Medico> GetByKey(string prKey);
		List<Medico> GetByName(string prName);
		Medico Save(Medico prMedico);
		Medico Update(Medico prMedico);
	}
}