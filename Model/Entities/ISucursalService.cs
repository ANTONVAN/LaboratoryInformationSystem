using System.Collections.Generic;

namespace ILab.Model
{
	public interface ISucursalService
	{
		void Delete(Sucursal prSucursal);
		List<Sucursal> GetAll();
		List<Sucursal> GetByKey(string prKey);
		List<Sucursal> GetByName(string prName);
		Sucursal Save(Sucursal prSucursal);
		Sucursal Update(Sucursal prSucursal);
	}
}