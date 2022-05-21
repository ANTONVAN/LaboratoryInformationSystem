using System.Collections.Generic;

namespace ILab.Model
{
	public interface IPaqueteService
	{
		void Delete(Paquete prPaquete);
		List<Paquete> GetAll();
		List<Paquete> GetByName(string prName);
		Paquete Save(Paquete prPaquete);
		Paquete Update(Paquete prPaquete);
	}
}