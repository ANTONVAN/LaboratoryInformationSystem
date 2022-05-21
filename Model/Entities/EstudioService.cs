using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILab.Model
{
    public class EstudioService : IEstudioService
    {
        public AppDataContext _context { get; set; }

        public EstudioService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
        }

        public List<Estudio> GetByName(string prName)
        {
            //.Include("Area").Include("Maquilador").Include("Metodo")
            var linq = from estudios in _context.Estudios.Include("Parametros")select estudios;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }
        public List<Estudio> GetByKey(string prKey)
        {
          var linq = from estudios in _context.Estudios.Include("Parametros") select estudios;
          if (!string.IsNullOrWhiteSpace(prKey))
            linq = linq.Where(x => x.Clave.ToUpper().Contains(prKey.ToUpper()));
          return linq.ToList();
        }

       public Estudio Save(Estudio prEstudio)
        {
            _context.Estudios.Add(prEstudio);
            _context.SaveChanges();
            return prEstudio;
        }

        public Estudio Update(Estudio prEstudio)
        {
          Estudio lEstudioFromDB = _context.Estudios.Include("Parametros").First(x => x.Id == prEstudio.Id);
          _context.Entry(lEstudioFromDB).CurrentValues.SetValues(prEstudio);

          if (prEstudio.Parametros!=null)
          {
              Parametro lParametroFromDB = _context.Parametros.First(x => x.Id == prEstudio.Parametros.First().Id);
              lEstudioFromDB.Parametros.Add(lParametroFromDB);
          } 
           
          _context.SaveChanges();
          return prEstudio; 
        }

        public void Delete(Estudio prEstudio)
        {
            _context.Entry(prEstudio).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
