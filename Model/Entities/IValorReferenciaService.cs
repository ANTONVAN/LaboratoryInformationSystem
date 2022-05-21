using System.Collections.Generic;

namespace ILab.Model
{
    public interface IValorReferenciaService
    {
        void Delete(ValorReferencia prValorReferencias);
        List<ValorReferencia> GetAll();
        List<ValorReferencia> GetByName(string prValorReferencias);
        ValorReferencia Save(ValorReferencia prValorReferencias);
        ValorReferencia Update(ValorReferencia prValorReferencias);
    }
}