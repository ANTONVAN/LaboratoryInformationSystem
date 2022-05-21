using ILab.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int departamentoId { get; set; }
        [ForeignKey("departamentoId")]
        public virtual Departamento Departamento { get; set; }
    }
}
