using DataManager.BOL.Common;
using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface IEmployeeDAL
    {
        Task<List<Employee>> GetAllEmployeesDal();
        Task<List<Employee>> GetEmployeesByFilterDal(EmployeeSearch searchObj);
        Task<Employee> GetEmployeeByIdDal(int id);
        Task<int> CreateNewEmployeeDal(Employee emp);
        Task<int> UpadateEmployeeByIdDal(Employee emp);///
        Task<int> DeleteEmployeeByIdDal(int id);
    }
}
