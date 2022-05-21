using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class ValorReferencia
    {
        [Key]
        public int Id { get; set; }
        public string Sexo { get; set; }
        public int Edad1 { get; set; }
        public int Edad2 { get; set; }
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public string Multiple { get; set; }
        public int parametroId { get; set; }
        public virtual Parametro Parametro { get; set; }

    }
}
