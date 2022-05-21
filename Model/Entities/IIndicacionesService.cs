using System.Collections.Generic;

namespace ILab.Model
{
    public interface IIndicacionesService
    {
        void Delete(Indicaciones prIndicaciones);
        List<Indicaciones> GetAll();
        List<Indicaciones> GetByName(string prName);
        Indicaciones Save(Indicaciones prIndicaciones);
        Indicaciones Update(Indicaciones prIndicaciones);
    }
}