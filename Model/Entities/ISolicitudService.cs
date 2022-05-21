using System.Collections.Generic;

namespace ILab.Model
{
	public interface ISolicitudService
	{
		void Delete(Solicitud prSolicitud);
		List<Solicitud> GetAll();
		List<Solicitud> GetById(int prId);
		Solicitud Save(Solicitud prSolicitud);
		Solicitud Update(Solicitud prSolicitud);
	}
}