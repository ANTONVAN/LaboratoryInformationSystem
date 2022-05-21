using System.Collections.Generic;

namespace ILab.Model
{
    public interface IMaquiladorService
    {
        void Delete(Maquilador prMaquiladors);
        List<Maquilador> GetAll();
        List<Maquilador> GetByName(string prName);
        Maquilador Save(Maquilador prMaquiladors);
        Maquilador Update(Maquilador prMaquiladors);
    }
}