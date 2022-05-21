using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class Parametro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatioria")]
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Unidades { get; set; }
        public bool Activo { get; set; }
        public int valorTipoId { get; set; }
        [ForeignKey("valorTipoId")]
        public virtual ValorTipo ValorTipo { get; set; }
        public virtual ICollection<ValorReferencia> ValorReferencias { get; set; }
        public virtual ICollection<Estudio> Estudios { get; set; }  
        public virtual ICollection<Reactivo> Reactivos { get; set; }

  }
}
