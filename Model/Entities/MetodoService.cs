using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class MetodoService : IMetodoService
    {
        public AppDataContext _context { get; set; }
        public MetodoService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Metodo> GetAll()
        {
            return _context.Metodos.ToList();
        }

        public List<Metodo> GetByName(string prName)
        {
            var linq = from metodos in _context.Metodos select metodos;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Metodo Save(Metodo prMetodo)
        {
            _context.Metodos.Add(prMetodo);
            _context.SaveChanges();
            return prMetodo;
        }

        public Metodo Update(Metodo prMetodo)
        {
            Metodo lMetodoFromDB = _context.Metodos.First(x => x.Id == prMetodo.Id);
            _context.Entry(lMetodoFromDB).CurrentValues.SetValues(prMetodo);
            _context.SaveChanges();
            return prMetodo;
        }

        public void Delete(Metodo prMetodo)
        {
            _context.Entry(prMetodo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
