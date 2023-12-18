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
    public class PositionDAL : IPositionDAL
    {
        private readonly IDapperORM _dapper;

        public PositionDAL(IDapperORM dapper)
        {
            this._dapper = dapper;
        }
        public async Task<List<Position>> GetAllPositionsDal()
        {
            var companies = new List<Position>();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = "SELECT * FROM [dbo].[Position]";
                    var result = await dbConnection.QueryAsync<Position>(sqlQuery, commandType: CommandType.Text);
                    companies = result.ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<Position> GetPositionByIdDal(int id)
        {
            var companies = new Position();
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"SELECT * FROM [dbo].[Position] WHERE id = {id}";
                    companies = await dbConnection.QueryFirstAsync<Position>(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return companies;
        }

        public async Task<int> CreateNewPositionDal(Position formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"INSERT INTO [dbo].[Position] (Title, Description) VALUES ('{formData.Title}', '{formData.Description}');";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> UpadatePositionByIdDal(Position formData)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"UPDATE [dbo].[Position] SET Title = '{formData.Title}', Description = '{formData.Description}' WHERE id = {formData.id};";
                    result = await dbConnection.ExecuteAsync(sqlQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return result;
        }

        public async Task<int> DeletePositionByIdDal(int id)
        {
            var result = 0;
            try
            {
                using (IDbConnection dbConnection = _dapper.GetDapperORM())
                {
                    var sqlQuery = $"DELETE FROM [dbo].[Position] WHERE id = '{id}'";
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
