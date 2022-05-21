using System.Collections.Generic;

namespace ILab.Model
{
	public interface IResultadoService
	{
		void Delete(Resultado prResultado);
		List<Resultado> GetAll();
		List<Resultado> GetById(int prId);
		Resultado Save(Resultado prResultado);
		Resultado Update(Resultado prResultado);
	}
}