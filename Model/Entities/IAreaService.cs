using System.Collections.Generic;

namespace ILab.Model
{
    public interface IAreaService
    {
        void Delete(Area prArea);
        List<Area> GetAll();
        List<Area> GetByName(string prName);
        Area Save(Area prArea);
        Area Update(Area prArea);
    }
}