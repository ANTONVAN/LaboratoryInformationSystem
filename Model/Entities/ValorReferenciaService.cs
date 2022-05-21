using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class ValorReferenciaService : IValorReferenciaService
    {
        public AppDataContext _context { get; set; }
        public ValorReferenciaService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<ValorReferencia> GetAll()
        {
            return _context.ValorReferencias.ToList();
        }

        public List<ValorReferencia> GetByName(string prName)
        {
            var linq = from valorReferencias in _context.ValorReferencias select valorReferencias;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Multiple.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public ValorReferencia Save(ValorReferencia prValorReferencias)
        {
            _context.ValorReferencias.AddRange(prValorReferencias);
            _context.SaveChanges();
            return prValorReferencias;
        }

        public ValorReferencia Update(ValorReferencia prValorReferencias)
        {
            ValorReferencia lValorReferenciasFromDB = _context.ValorReferencias.First(x => x.Id == prValorReferencias.Id);
            _context.Entry(lValorReferenciasFromDB).CurrentValues.SetValues(prValorReferencias);
            _context.SaveChanges();
            return prValorReferencias;
        }

        public void Delete(ValorReferencia prValorReferencias)
        {
            _context.Entry(prValorReferencias).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
