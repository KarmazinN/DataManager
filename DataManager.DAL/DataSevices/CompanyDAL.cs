using Dapper;
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
    public class CompanyDAL : ICompanyDAL
    {
        private readonly IDapperORM _dapper;

        public CompanyDAL(IDapperORM dapper)
        {
            this._dapper = dapper;
        }
        public async Task<List<Company>> GetAllCompaniesDal()
        {
            var companies = new List<Company>();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = "SELECT * FROM [dbo].[Company]";
                    var result = await dbConnection.QueryAsync<Company>(sqlQuery, commandType: CommandType.Text);
                    companies = result.ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<Company> GetCompanyByIdDal(int id)
        {
            var companies = new Company();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"SELECT * FROM [dbo].[Company] WHERE id = {id}";
                    companies = await dbConnection.QueryFirstAsync<Company>(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<int> CreateNewCompanyDal(Company formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"INSERT INTO [dbo].[Company] (Title, Description) VALUES ('{formData.Title}', '{formData.Description}');";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> UpadateCompanyByIdDal(Company formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"UPDATE [dbo].[Company] SET Title = '{formData.Title}', Description = '{formData.Description}' WHERE id = {formData.id};";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> DeleteCompanyByIdDal(int id)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"DELETE FROM [dbo].[Company] WHERE id = '{id}'";
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
