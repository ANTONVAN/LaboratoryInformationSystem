using System.Collections.Generic;

namespace ILab.Model
{
    public interface IEtiquetaService
    {
        void Delete(Etiqueta prEtiquetas);
        List<Etiqueta> GetAll();
        List<Etiqueta> GetByName(string prName);
        Etiqueta Save(Etiqueta prEtiquetas);
        Etiqueta Update(Etiqueta prEtiquetas);
    }
}