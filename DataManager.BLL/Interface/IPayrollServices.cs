using DataManager.BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Interface
{
    public interface IPayrollServices
    {
        Task<List<CompanyСosts>> GetCompanyСostsData();
        Task<List<HumanResourse>> GetHumanResourseData();
    }
}
