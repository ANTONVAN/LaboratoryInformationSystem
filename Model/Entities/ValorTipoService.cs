using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class ValorTipoService : IValorTipoService
    {
        public AppDataContext _context { get; set; }
        public ValorTipoService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<ValorTipo> GetAll()
        {
            return _context.ValorTipos.ToList();
        }

        public List<ValorTipo> GetByName(string prName)
        {
            var linq = from valorTipo in _context.ValorTipos select valorTipo;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public ValorTipo Save(ValorTipo prValorTipo)
        {
            _context.ValorTipos.Add(prValorTipo);
            _context.SaveChanges();
            return prValorTipo;
        }

        public ValorTipo Update(ValorTipo prValorTipo)
        {
            ValorTipo lValorTipoFromDB = _context.ValorTipos.First(x => x.Id == prValorTipo.Id);
            _context.Entry(lValorTipoFromDB).CurrentValues.SetValues(prValorTipo);
            _context.SaveChanges();
            return prValorTipo;
        }

        public void Delete(ValorTipo prValorTipo)
        {
            _context.Entry(prValorTipo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
