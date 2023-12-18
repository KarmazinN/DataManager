using DataManager.DAL.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.DAL.Orm
{
    public class DapperORM : IDapperORM
    {
        private readonly IConfiguration _configuration;
        public string ConnectionStrings { get; set; }
        public string ProviderName { get; }


        public DapperORM(IConfiguration configuration) 
        {
            this._configuration = configuration;

            ConnectionStrings = _configuration.GetConnectionString("DefaultConnections");
            ProviderName = "System.Data.SqlClient";
        }

        public IDbConnection GetDapperORM()
        {
            return new SqlConnection(ConnectionStrings);
        }
    }
}
