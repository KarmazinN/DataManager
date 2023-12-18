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
    public class DepartamentDAL : IDepartamentDAL
    {
        private readonly IDapperORM _dapper;

        public DepartamentDAL(IDapperORM dapper)
        {
            this._dapper = dapper;
        }
        public async Task<List<Departament>> GetAllDepartamentsDal()
        {
            var companies = new List<Departament>();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = "SELECT * FROM [dbo].[Departament]";
                    var result = await dbConnection.QueryAsync<Departament>(sqlQuery, commandType: CommandType.Text);
                    companies = result.ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<Departament> GetDepartamentByIdDal(int id)
        {
            var companies = new Departament();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"SELECT * FROM [dbo].[Departament] WHERE id = {id}";
                    companies = await dbConnection.QueryFirstAsync<Departament>(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<int> CreateNewDepartamentDal(Departament formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"INSERT INTO [dbo].[Departament] (Title, Description) VALUES ('{formData.Title}', '{formData.Description}');";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> UpadateDepartamentByIdDal(Departament formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"UPDATE [dbo].[Departament] SET Title = '{formData.Title}', Description = '{formData.Description}' WHERE id = {formData.id};";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> DeleteDepartamentByIdDal(int id)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"DELETE FROM [dbo].[Departament] WHERE id = '{id}'";
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
