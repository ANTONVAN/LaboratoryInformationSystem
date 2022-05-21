using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class MaquiladorService : IMaquiladorService
    {
        public AppDataContext _context { get; set; }
        public MaquiladorService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Maquilador> GetAll()
        {
            return _context.Maquiladores.ToList();
        }

        public List<Maquilador> GetByName(string prName)
        {
            var linq = from maquiladores in _context.Maquiladores select maquiladores;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Maquilador Save(Maquilador prMaquiladors)
        {
            _context.Maquiladores.Add(prMaquiladors);
            _context.SaveChanges();
            return prMaquiladors;
        }

        public Maquilador Update(Maquilador prMaquiladors)
        {
            Maquilador lMaquiladorsFromDB = _context.Maquiladores.First(x => x.Id == prMaquiladors.Id);
            _context.Entry(lMaquiladorsFromDB).CurrentValues.SetValues(prMaquiladors);
            _context.SaveChanges();
            return prMaquiladors;
        }

        public void Delete(Maquilador prMaquiladors)
        {
            _context.Entry(prMaquiladors).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
