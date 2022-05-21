using System.Collections.Generic;

namespace ILab.Model
{
	public interface ICatPrecioService
	{
		void Delete(CatPrecio prPrecio);
		List<CatPrecio> GetAll();
		List<CatPrecio> GetByKey(string prKey);
		List<CatPrecio> GetByName(string prName);
		CatPrecio Save(CatPrecio prPrecio);
		CatPrecio Update(CatPrecio prPrecio);
	}
}