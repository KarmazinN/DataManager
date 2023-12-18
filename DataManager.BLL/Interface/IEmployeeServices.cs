using DataManager.BOL.Common;
using DataManager.BOL.Entity;
using DataManager.BOL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Interface
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployees();
        Task<List<EmployeeViewModel>> SeachEmployees(EmployeeSearch searchOptions);
        Task<EmployeeViewModel> GetEmployeeById(int id);
        Task<bool> CreateNewEmployee(CreateEmployeeViewModel employeeView);
        Task<bool> UpadateEmployee(CreateEmployeeViewModel employeeView);
        Task<bool> DeleteEmployeeById(int id);
        Task FielRecordingAsync(string filePath);
    }
}
