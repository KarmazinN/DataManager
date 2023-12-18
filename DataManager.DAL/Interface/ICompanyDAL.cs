using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface ICompanyDAL
    {
        Task<List<Company>> GetAllCompaniesDal();
        Task<Company> GetCompanyByIdDal(int id);
        Task<int> CreateNewCompanyDal(Company formData);
        Task<int> UpadateCompanyByIdDal(Company formData);
        Task<int> DeleteCompanyByIdDal(int id);
    }
}
