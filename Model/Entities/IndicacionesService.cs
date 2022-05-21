using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class IndicacionesService : IIndicacionesService
    {
        public AppDataContext _context { get; set; }
        public IndicacionesService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Indicaciones> GetAll()
        {
            return _context.Indicaciones.ToList();
        }

        public List<Indicaciones> GetByName(string prName)
        {
            var linq = from indicaciones in _context.Indicaciones select indicaciones;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Indicaciones Save(Indicaciones prIndicaciones)
        {
            _context.Indicaciones.Add(prIndicaciones);
            _context.SaveChanges();
            return prIndicaciones;
        }

        public Indicaciones Update(Indicaciones prIndicaciones)
        {
            Indicaciones lIndicacionesFromDB = _context.Indicaciones.First(x => x.Id == prIndicaciones.Id);
            _context.Entry(lIndicacionesFromDB).CurrentValues.SetValues(prIndicaciones);
            _context.SaveChanges();
            return prIndicaciones;
        }

        public void Delete(Indicaciones prIndicaciones)
        {
            _context.Entry(prIndicaciones).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
