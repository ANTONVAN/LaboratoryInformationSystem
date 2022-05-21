using System.Collections.Generic;

namespace ILab.Model
{
    public interface IMetodoService
    {
        void Delete(Metodo prMetodo);
        List<Metodo> GetAll();
        List<Metodo> GetByName(string prName);
        Metodo Save(Metodo prMetodo);
        Metodo Update(Metodo prMetodo);
    }
}