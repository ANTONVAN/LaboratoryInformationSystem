using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Paciente
	{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    public string Apellidos { get; set; }
    [Required(ErrorMessage = "El sexo es obligatorio")]
    public string Sexo { get; set;}
    public string Direccion { get; set; }
    [Required(ErrorMessage = "La edad es obligatoria")]
    public int Edad { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime FechaNacimiento { get; set; }

    public uint Celular { get; set; }  
    public uint Telefono { get; set; }
    public int CP { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual ICollection<Solicitud> Solicitudes { get; set; }
  }
}
