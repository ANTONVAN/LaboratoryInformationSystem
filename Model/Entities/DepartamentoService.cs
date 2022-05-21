using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.Model
{
    public class DepartamentoService : IDepartamentoService
    {
        public AppDataContext _context { get; set; }
        public DepartamentoService(AppDataContext prAppDataContext)
        {
            _context = prAppDataContext;
        }

        public List<Departamento> GetAll()
        {
            return _context.Departamentos.ToList();
        }

        public List<Departamento> GetByName(string prName)
        {
            var linq = from departamentos in _context.Departamentos select departamentos;
            if (!string.IsNullOrWhiteSpace(prName))
                linq = linq.Where(x => x.Nombre.ToUpper().Contains(prName.ToUpper()));
            return linq.ToList();
        }

        public Departamento Save(Departamento prDepartamento)
        {
            _context.Departamentos.Add(prDepartamento);
            _context.SaveChanges();
            return prDepartamento;
        }

        public Departamento Update(Departamento prDepartamento)
        {
            Departamento lDepartamentoFromDB = _context.Departamentos.First(x => x.Id == prDepartamento.Id);
            _context.Entry(lDepartamentoFromDB).CurrentValues.SetValues(prDepartamento);
            _context.SaveChanges();
            return prDepartamento;
        }

        public void Delete(Departamento prDepartamento)
        {
            _context.Entry(prDepartamento).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}
