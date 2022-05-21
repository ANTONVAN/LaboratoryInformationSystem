using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class EstudioSol
	{
		[Key]
		public int Id { get; set; }
		public int estudioId { get; set; }
		public virtual Estudio Estudio { get; set; }
		public int solicitudId { get; set; }
		public virtual Solicitud Solicitud { get; set; }
		public virtual ICollection<Resultado> Resultados { get; set; }
	}
}
