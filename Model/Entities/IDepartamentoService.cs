using System.Collections.Generic;

namespace ILab.Model
{
    public interface IDepartamentoService
    {
        List<Departamento> GetAll();
        List<Departamento> GetByName(string prName);
        Departamento Save(Departamento prDepartamento);
        Departamento Update(Departamento prDepartamento);
        void Delete(Departamento prDepartamento);
    }
}