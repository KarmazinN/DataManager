using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface IDepartamentDAL
    {
        Task<List<Departament>> GetAllDepartamentsDal();
        Task<Departament> GetDepartamentByIdDal(int id);
        Task<int> CreateNewDepartamentDal(Departament formData);
        Task<int> UpadateDepartamentByIdDal(Departament formData);
        Task<int> DeleteDepartamentByIdDal(int id);
    }
}
