using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class EtiquetaService : IEtiquetaService
    {
        public AppDataContext _context { get; set; }
        public EtiquetaService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Etiqueta> GetAll()
        {
            return _context.Etiquetas.ToList();
        }

        public List<Etiqueta> GetByName(string prName)
        {
            var linq = from etiquetas in _context.Etiquetas select etiquetas;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Etiqueta Save(Etiqueta prEtiquetas)
        {
            _context.Etiquetas.Add(prEtiquetas);
            _context.SaveChanges();
            return prEtiquetas;
        }

        public Etiqueta Update(Etiqueta prEtiquetas)
        {
            Etiqueta lEtiquetasFromDB = _context.Etiquetas.First(x => x.Id == prEtiquetas.Id);
            _context.Entry(lEtiquetasFromDB).CurrentValues.SetValues(prEtiquetas);
            _context.SaveChanges();
            return prEtiquetas;
        }

        public void Delete(Etiqueta prEtiquetas)
        {
            _context.Entry(prEtiquetas).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
