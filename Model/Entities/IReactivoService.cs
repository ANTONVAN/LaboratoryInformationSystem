using System.Collections.Generic;

namespace ILab.Model
{
	public interface IReactivoService
	{
		void Delete(Reactivo prReactivo);
		List<Reactivo> GetAll();
		List<Reactivo> GetByName(string prName);
		Reactivo Save(Reactivo prReactivo);
		Reactivo Update(Reactivo prReactivo);
	}
}