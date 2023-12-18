using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Interface
{
    public interface ICompanyServices
    {
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompaniesById(int id);
        Task<bool> CreateNewCompany(Company formData);
        Task<bool> UpadateCompany(Company formData);
        Task<bool> DeleteCompanyById(int id);
    }
}
