using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface IPositionDAL
    {
        Task<List<Position>> GetAllPositionsDal();
        Task<Position> GetPositionByIdDal(int id);
        Task<int> CreateNewPositionDal(Position formData);
        Task<int> UpadatePositionByIdDal(Position formData);
        Task<int> DeletePositionByIdDal(int id);
    }
}
