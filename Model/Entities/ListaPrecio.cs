using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class ListaPrecio
	{
		[Key]
		public int Id { get; set; }
		public DateTime FechaCreacion { get; set; }
		public int estudioId { get; set; }
		[ForeignKey("estudioId")]
		public virtual Estudio Estudio { get; set; }
		public int catPrecioId { get; set; }
		[ForeignKey("catPrecioId")]
		public virtual CatPrecio CatPrecios { get; set; }
		public int Precio { get; set; }
		public bool Activo { get; set; }
	}
}
