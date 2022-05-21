using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Resultado
	{
		[Key]
		public int Id { get; set; }
		public int estudioSolId { get; set; }
		[ForeignKey("estudioSolId")]
		public virtual EstudioSol EstudioSol { get; set; }
	}
}
