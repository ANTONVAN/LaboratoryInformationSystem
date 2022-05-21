using System.Collections.Generic;

namespace ILab.Model
{
    public interface IParametroService
    {
      void Delete(Parametro prParametro);
      List<Parametro> GetAll();
      List<Parametro> GetByName(string prName);

      List<Parametro> GetByKey(string prKey);
      Parametro Save(Parametro prParametro);
      Parametro Update(Parametro prParametro);
    }
}