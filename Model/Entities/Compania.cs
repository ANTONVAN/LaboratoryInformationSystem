using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Compania
	{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La clave es obligatioria")]
    public string Clave { get; set; }
    public string Contrasena { get; set; }
    public string NombreComercial { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string MetodoPago { get; set; }
    public string RazonSocial { get; set; }
    public string RFC { get; set; }
    public int CP { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public string Status { get; set; }
    
    public bool Activo { get; set; }  

    public int catPrecioId { get; set; }
    [ForeignKey("catPrecioId")]
    public virtual CatPrecio CatPrecio { get; set; }
  }
}
