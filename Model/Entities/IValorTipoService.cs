using System.Collections.Generic;

namespace ILab.Model
{
    public interface IValorTipoService
    {
        void Delete(ValorTipo prParametroTipo);
        List<ValorTipo> GetAll();
        List<ValorTipo> GetByName(string prName);
        ValorTipo Save(ValorTipo prParametroTipo);
        ValorTipo Update(ValorTipo prParametroTipo);
    }
}