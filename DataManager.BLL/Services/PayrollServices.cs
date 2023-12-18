using DataManager.BLL.Interface;
using DataManager.BOL.Common;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Services
{
    public class PayrollServices : IPayrollServices
    {
        private readonly IPayrollDAL _payroll;

        public PayrollServices(IPayrollDAL payroll)
        {
            _payroll = payroll;
        }

        public async Task<List<CompanyСosts>> GetCompanyСostsData()
        {
            return await _payroll.GetCompanyСostsDal();
        }

        public async Task<List<HumanResourse>> GetHumanResourseData()
        {
            return await _payroll.GetCompanyEmployeeCount();
        }
    }
}
