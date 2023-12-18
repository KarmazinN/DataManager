using DataManager.BLL.Interface;
using DataManager.BOL.Entity;
using DataManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BLL.Services
{
    public class PositionServices : IPositionServices
    {
        public readonly IPositionDAL _position;

        public PositionServices(IPositionDAL position)
        {
            this._position = position;
        }

        public async Task<List<Position>> GetPositions()
        {
            var list = await _position.GetAllPositionsDal();
            return list;
        }

        public async Task<Position> GetPositionsById(int id)
        {
            var result = await _position.GetPositionByIdDal(id);
            return result;
        }

        public async Task<bool> CreateNewPosition(Position formData)
        {
            var result = await _position.CreateNewPositionDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> UpadatePosition(Position formData)
        {
            var result = await _position.UpadatePositionByIdDal(formData);
            if (result != 0)
                return true;
            else return false;
        }

        public async Task<bool> DeletePositionById(int id)
        {
            var result = await _position.DeletePositionByIdDal(id);
            if (result != 0)
                return true;
            else return false;
        }
    }
}
