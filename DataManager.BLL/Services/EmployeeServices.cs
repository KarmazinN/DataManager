using DataManager.BLL.Interface;
using DataManager.BOL.Common;
using DataManager.BOL.Entity;
using DataManager.BOL.ViewModel;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        public readonly IEmployeeDAL _employee;
        public readonly ICompanyDAL _company;
        public readonly IPositionDAL _position;
        public readonly IDepartamentDAL _departament;

        public EmployeeServices(IEmployeeDAL employee, ICompanyDAL company, IPositionDAL position, IDepartamentDAL departament)
        {
            _employee = employee;
            _company = company;
            _position = position;
            _departament = departament;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var list = await _employee.GetAllEmployeesDal();
            return list;
        }

        public async Task<List<EmployeeViewModel>> SeachEmployees(EmployeeSearch searchOptions)
        {
            var result = new List<EmployeeViewModel>();
            var eployees = await _employee.GetEmployeesByFilterDal(searchOptions);
            var departaments = await _departament.GetAllDepartamentsDal();
            var positions = await _position.GetAllPositionsDal();
            var company = await _company.GetAllCompaniesDal();
            
            foreach (var employee in eployees)
            {
                result.Add(new EmployeeViewModel
                {
                    id = employee.id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    Adress = employee.Adress,
                    Phone = employee.Phone,
                    BirthDate = employee.BirthDate,
                    EntryDay = employee.EntryDay,
                    Salary = employee.Salary,
                    Departament = departaments.Find(x => x.id == employee.Departament_Id)?.Title ?? "",
                    Position = positions.Find(x => x.id == employee.Position_Id)?.Title ?? "",
                    Company = company.Find(x => x.id == employee.Company_Id)?.Title ?? "",
                });
            }

            return result;
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            var employee = await _employee.GetEmployeeByIdDal(id);
            var departaments = await _departament.GetAllDepartamentsDal();
            var positions = await _position.GetAllPositionsDal();
            var company = await _company.GetAllCompaniesDal();

            var result = new EmployeeViewModel()
            {
                id = employee.id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Adress = employee.Adress,
                Phone = employee.Phone,
                BirthDate = employee.BirthDate,
                EntryDay = employee.EntryDay,
                Salary = employee.Salary,
                Departament = departaments.Find(x => x.id == employee.Departament_Id)?.Title ?? "",
                Position = positions.Find(x => x.id == employee.Position_Id)?.Title ?? "",
                Company = company.Find(x => x.id == employee.Company_Id)?.Title ?? "",
            };

            return result;
        }

        public async Task<bool> CreateNewEmployee(CreateEmployeeViewModel employeeView)
        {
            var employee = new Employee()
            {
                id = employeeView.id,
                FirstName = employeeView.FirstName,
                LastName = employeeView.LastName,
                Patronymic = employeeView.Patronymic,
                Adress = employeeView.Adress,
                Phone = employeeView.Phone,
                BirthDate = employeeView.BirthDate,
                EntryDay = employeeView.EntryDay,
                Salary = employeeView.Salary,
                Departament_Id = employeeView.Departament_Id,
                Position_Id = employeeView.Position_Id,
                Company_Id = employeeView.Company_Id,
            };
            var result = await _employee.CreateNewEmployeeDal(employee);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> UpadateEmployee(CreateEmployeeViewModel employeeView)
        {
            var employee = new Employee()
            {
                id = employeeView.id,
                FirstName = employeeView.FirstName,
                LastName = employeeView.LastName,
                Patronymic = employeeView.Patronymic,
                Adress = employeeView.Adress,
                Phone = employeeView.Phone,
                BirthDate = employeeView.BirthDate,
                EntryDay = employeeView.EntryDay,
                Salary = employeeView.Salary,
                Departament_Id = employeeView.Departament_Id,
                Position_Id = employeeView.Position_Id,
                Company_Id = employeeView.Company_Id,
            };
            var result = await _employee.UpadateEmployeeByIdDal(employee);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            var result = await _employee.DeleteEmployeeByIdDal(id);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task FielRecordingAsync(string filePath)
        {
            string Path = filePath;
            File.WriteAllText(filePath, string.Empty);

            var departaments = await _departament.GetAllDepartamentsDal();
            var positions = await _position.GetAllPositionsDal();
            var company = await _company.GetAllCompaniesDal();
            var emoloyes = await _employee.GetAllEmployeesDal();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in emoloyes)
                {
                    var departament = departaments.Find(x => x.id == item.Departament_Id)?.Title ?? "";
                    var position = positions.Find(x => x.id == item.Position_Id)?.Title ?? "";
                    var comp = company.Find(x => x.id == item.Company_Id)?.Title ?? "";
                    await writer.WriteLineAsync($"{item.id}, {item.FirstName}, {item.LastName}, {item.Patronymic}, {item.BirthDate}, {item.EntryDay}, {item.Salary}, {item.Phone}, {departament}, {position}, {comp}; ");
                }

            }
        }
    }
}
