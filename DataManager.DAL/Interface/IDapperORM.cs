using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Interface
{
    public interface IDapperORM
    {
        IDbConnection GetDapperORM();
    }
}
