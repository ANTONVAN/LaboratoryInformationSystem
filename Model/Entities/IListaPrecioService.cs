using System.Collections.Generic;

namespace ILab.Model
{
	public interface IListaPrecioService
	{
		void Delete(ListaPrecio prPrecio);
		List<ListaPrecio> GetAll();
		List<ListaPrecio> GetByEstudioAndCatPrecio(int prEstudioId, int prCatPrecioId);
		ListaPrecio Save(ListaPrecio prPrecio);
		ListaPrecio Update(ListaPrecio prPrecio);
	}
}