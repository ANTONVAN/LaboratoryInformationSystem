using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Medico
	{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La clave es obligatoria")]
    public string Apellidos { get; set; }
    public string Especialidad { get; set; }
    public string Empresa { get; set; }
    public string Clinica { get; set; }
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
    public int Celular { get; set; }
    public bool Activo { get; set; }
  }
}
