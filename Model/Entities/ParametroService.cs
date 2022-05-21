using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class ParametroService : IParametroService
    {
        public AppDataContext _context { get; set; }
        public ParametroService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Parametro> GetAll()
        {
            return _context.Parametros.Include(m => m.ValorReferencias).ToList();
        }

        public List<Parametro> GetByName(string prName)
        {
            var linq = from parametros in _context.Parametros.Include(m => m.ValorReferencias).Include(m => m.ValorTipo).Include("ValorTipo") select parametros;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public List<Parametro> GetByKey(string prKey)
        {
          var linq = from parametros in _context.Parametros.Include(m => m.ValorReferencias).Include(m => m.ValorTipo).Include("ValorTipo") select parametros;
          if (!string.IsNullOrWhiteSpace(prKey))
            linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
          return linq.ToList();
        }

        public Parametro Save(Parametro prParametro)
        {
            _context.Parametros.Add(prParametro);
            _context.SaveChanges();
            return prParametro;
        }

        public Parametro Update(Parametro prParametro)
        {
            Parametro lParametroFromDB = _context.Parametros.Include(m => m.ValorReferencias).First(x => x.Id == prParametro.Id);
            _context.Entry(lParametroFromDB).CurrentValues.SetValues(prParametro);

            if (prParametro.ValorReferencias != null)
            {
                ValorReferencia lValorReferenciaFromDB = _context.ValorReferencias.First(x => x.Id == prParametro.ValorReferencias.First().Id);
                lParametroFromDB.ValorReferencias.Add(lValorReferenciaFromDB);
            }

            _context.SaveChanges();
            return prParametro;
        }

        public void Delete(Parametro prParametro)
        {
            _context.Entry(prParametro).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
