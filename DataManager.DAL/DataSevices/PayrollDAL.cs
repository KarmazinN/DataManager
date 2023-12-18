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
    public class PayrollDAL : IPayrollDAL
    {
        private readonly IDapperORM _dapper;

        public PayrollDAL(IDapperORM dapper)
        {
            this._dapper = dapper;
        }

        public async Task<List<CompanyСosts>> GetCompanyСostsDal()
        {
            using (IDbConnection dbConnection = _dapper.GetDapperORM())
            {
                var sqlQuery = @"
                    SELECT c.id AS id, c.Title AS Company, SUM(e.Salary) AS TotalSalary 
                    FROM Company c 
                    JOIN Employee e ON c.id = e.Company_Id 
                    GROUP BY c.id, c.Title;
                ";

                var queryResult = await dbConnection.QueryAsync<CompanyСosts>(sqlQuery, commandType: CommandType.Text);
                return queryResult.ToList();
            }
        }

        public async Task<List<HumanResourse>> GetCompanyEmployeeCount()
        {
            using (IDbConnection dbConnection = _dapper.GetDapperORM())
            {
                var sqlQuery = @"
                    SELECT c.id AS CompanyId, c.Title AS CompanyTitle, COUNT(e.id) AS NumberOfEmployees 
                    FROM Company c 
                    LEFT JOIN Employee e ON c.id = e.Company_Id 
                    GROUP BY c.id, c.Title;
                ";

                var queryResult = await dbConnection.QueryAsync<HumanResourse>(sqlQuery, commandType: CommandType.Text);
                return queryResult.ToList();
            }
        }
    }
}
