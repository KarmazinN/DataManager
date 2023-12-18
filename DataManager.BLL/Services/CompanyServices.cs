using DataManager.BLL.Interface;
using DataManager.BOL.Entity;
using DataManager.DAL.DataSevices;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Services
{
    public class CompanyServices : ICompanyServices
    {
        public readonly ICompanyDAL _company;

        public CompanyServices(ICompanyDAL company)
        {
            this._company = company;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var list = await _company.GetAllCompaniesDal();
            return list;
        }

        public async Task<Company> GetCompaniesById(int id)
        {
            var result = await _company.GetCompanyByIdDal(id);
            return result;
        }

        public async Task<bool> CreateNewCompany(Company formData)
        {
            var result = await _company.CreateNewCompanyDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> UpadateCompany(Company formData)
        {
            var result = await _company.UpadateCompanyByIdDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> DeleteCompanyById(int id)
        {
            var result = await _company.DeleteCompanyByIdDal(id);
            if (result != 0)
                return true;
            else return false;
        }
    }
}
