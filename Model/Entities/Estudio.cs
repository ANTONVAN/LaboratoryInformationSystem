using ILab.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class Estudio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public int areaId { get; set; }
        [ForeignKey("areaId")]
        public virtual Area Area { get; set; }
        public int metodoId { get; set; }
        [ForeignKey("metodoId")]
        public virtual Metodo Metodo { get; set; }
        public int maquiladorId { get; set; }
        [ForeignKey("maquiladorId")]
        public virtual Maquilador Maquilador { get; set; }
        public virtual ICollection<Indicaciones> Indicaciones{get; set;}
        public virtual ICollection<Etiqueta> Etiquetas {get; set; }
        public virtual ICollection<Paquete> Paquetes { get; set; }
        public virtual ICollection<Parametro> Parametros { get; set; }
        
  }
}
