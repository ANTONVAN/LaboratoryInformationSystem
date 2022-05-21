using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Sucursal
	{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La clave es obligatoria")]
    public string Clave { get; set; }
    public int CP { get; set; }
    public string Estado { get; set; }
    public string Ciudad { get; set; }
    public int NumeroExterior { get; set; }
    public int NumeroInterior { get; set; }
    public string Calle { get; set; }
    public int Colonia { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public bool Activo { get; set; }
    
  }
}
