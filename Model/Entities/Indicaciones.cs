using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class Indicaciones
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        public bool Activo { get; set; }
    public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
