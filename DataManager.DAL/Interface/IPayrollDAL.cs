using DataManager.BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface IPayrollDAL
    {
        Task<List<CompanyСosts>> GetCompanyСostsDal();
        Task<List<HumanResourse>> GetCompanyEmployeeCount();
    }
}
