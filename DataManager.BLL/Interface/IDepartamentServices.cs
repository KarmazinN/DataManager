using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Interface
{
    public interface IDepartamentServices
    {
        Task<List<Departament>> GetDepartaments();
        Task<Departament> GetDepartamentById(int id);
        Task<bool> CreateNewDepartament(Departament formData);
        Task<bool> UpadateDepartament(Departament formData);
        Task<bool> DeleteDepartamentById(int id);
    }
}
