using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class CatPrecio
	{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La clave es obligatioria")]
    public string Clave { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual ICollection<ListaPrecio> ListaPrecios { get; set; }
    public virtual ICollection<Compania> Companias { get; set; }
  }
}
