using ILab.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class AreaService : IAreaService
    {
        public AppDataContext _context { get; set; }
        public AreaService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Area> GetAll()
        {
            return _context.Areas.ToList();
        }

        public List<Area> GetByName(string prName)
        {
            var linq = from areas in _context.Areas.Include("Departamento") select areas;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Area Save(Area prArea)
        {
            _context.Areas.Add(prArea);
            _context.SaveChanges();
            return prArea;
        }

        public Area Update(Area prArea)
        {
            Area lAreaFromDB = _context.Areas.First(x => x.Id == prArea.Id);
            _context.Entry(lAreaFromDB).CurrentValues.SetValues(prArea);
            _context.SaveChanges();
            return prArea;
        }

        public void Delete(Area prArea)
        {
            _context.Entry(prArea).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
        
    }
}
