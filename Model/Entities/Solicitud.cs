using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
	public class Solicitud
	{
    [Key]
    public int Id { get; set; }
    public double Total { get; set; }
    public string Status { get; set; }
    public double Cargo { get; set; }
    public double Descuento { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int companiaId { get; set; }
    public virtual Compania Compania { get; set; }
    public int medicoId { get; set; }
    public virtual Medico Medico { get; set; }
    public int pacienteId { get; set; }
    public virtual Paciente Paciente { get; set; }
    public virtual ICollection<EstudioSol> EstudioSols { get; set; }
  }
}
