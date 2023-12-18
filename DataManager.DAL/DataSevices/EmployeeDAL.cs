using Dapper;
using DataManager.BOL.Common;
using DataManager.BOL.Entity;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.DataSevices
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly IDapperORM _dapper;

        public EmployeeDAL(IDapperORM dapper)
        {
            this._dapper = dapper;
        }
        public async Task<List<Employee>> GetAllEmployeesDal()
        {
            var employees = new List<Employee>();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = "SELECT * FROM [dbo].[Employee]";
                    var results = await dbConnection.QueryAsync<Employee>(sqlQuery, commandType: CommandType.Text);
                    employees = results.ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return employees;
        }

        public async Task<List<Employee>> GetEmployeesByFilterDal(EmployeeSearch searchObj)
        {
            var employees = new List<Employee>();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"SELECT * FROM Employee WHERE (LOWER(FirstName) LIKE LOWER('%{searchObj.FistName}%') AND LOWER(LastName) LIKE LOWER('%{searchObj.LastName}%'))" ;
                    var results = await dbConnection.QueryAsync<Employee>(sqlQuery, commandType: CommandType.Text);
                    employees = results.ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return employees;
        }

        public async Task<Employee> GetEmployeeByIdDal(int id)
        {
            var companies = new Employee();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"SELECT * FROM [dbo].[Employee] WHERE id = {id}";
                    companies = await dbConnection.QueryFirstAsync<Employee>(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<int> CreateNewEmployeeDal(Employee emp)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"INSERT INTO [dbo].[Employee] (FirstName, LastName, Patronymic, Adress, Phone, BirthDay, EntryDay, Salary, Departament_Id, Position_Id, Company_Id) " +
                        $"values ('{emp.FirstName}', '{emp.LastName}', '{emp.Patronymic}', '{emp.Adress}', '{emp.Phone}', '{emp.BirthDate}', '{emp.EntryDay}', {emp.Salary}, {emp.Departament_Id}, {emp.Position_Id}, {emp.Company_Id});";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> UpadateEmployeeByIdDal(Employee emp)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"UPDATE Employee SET " +
                        $" FirstName = '{emp.FirstName}', " +
                        $" LastName = '{emp.LastName}', " +
                        $" Patronymic = '{emp.Patronymic}', " +
                        $" Adress = '{emp.Adress}', " +
                        $" Phone = '{emp.Phone}', " +
                        $" BirthDay = '{emp.BirthDate}'," +
                        $" EntryDay = '{emp.EntryDay}'," +
                        $" Salary = {emp.Salary}," +
                        $" Departament_Id = {emp.Departament_Id}," +
                        $" Position_Id = {emp.Position_Id}, " +
                        $" Company_Id = {emp.Company_Id} " +
                        $" WHERE id = {emp.id};";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> DeleteEmployeeByIdDal(int id)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"DELETE FROM [dbo].[Employee] WHERE id = '{id}'";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }
    }
}
