using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model.Entities
{
    public class EstudioIndicaciones
    {
        public Estudio Estudios { get; set; }
        public int EstudioId { get; set; }
        public Parametro Indicaciones { get; set; }
        public int IndicacionesId { get; set; }
    }
}
