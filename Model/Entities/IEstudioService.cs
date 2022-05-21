using System.Collections.Generic;

namespace ILab.Model
{
    public interface IEstudioService
    {
        void Delete(Estudio prEstudio);
        List<Estudio> GetAll();
        List<Estudio> GetByName(string prName);
        List<Estudio> GetByKey(string prKey);
        Estudio Save(Estudio prEstudio);
        Estudio Update(Estudio prEstudio);
    }
}