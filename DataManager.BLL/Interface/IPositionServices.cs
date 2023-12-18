using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Interface
{
    public interface IPositionServices
    {
        Task<List<Position>> GetPositions();
        Task<Position> GetPositionsById(int id);
        Task<bool> CreateNewPosition(Position formData);
        Task<bool> UpadatePosition(Position formData);
        Task<bool> DeletePositionById(int id);
    }
}
