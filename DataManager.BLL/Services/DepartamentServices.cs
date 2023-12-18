using DataManager.BLL.Interface;
using DataManager.BOL.Entity;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Services
{
    public class DepartamentServices : IDepartamentServices
    {
        public readonly IDepartamentDAL _departament;

        public DepartamentServices(IDepartamentDAL departament)
        {
            this._departament = departament;
        }

        public async Task<List<Departament>> GetDepartaments()
        {
            var list = await _departament.GetAllDepartamentsDal();
            return list;
        }

        public async Task<Departament> GetDepartamentById(int id)
        {
            var result = await _departament.GetDepartamentByIdDal(id);
            return result;
        }

        public async Task<bool> CreateNewDepartament(Departament formData)
        {
            var result = await _departament.CreateNewDepartamentDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> UpadateDepartament(Departament formData)
        {
            var result = await _departament.UpadateDepartamentByIdDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> DeleteDepartamentById(int id)
        {
            var result = await _departament.DeleteDepartamentByIdDal(id);
            if (result != 0)
                return true;
            else return false;
        }
    }
}
