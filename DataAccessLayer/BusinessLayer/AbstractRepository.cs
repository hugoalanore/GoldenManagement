using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public abstract class AbstractRepository : IDisposable
    {
        public readonly IDbConnection db;

        protected AbstractRepository()
        {
            db = new MySqlConnection(ConfigurationManager.ConnectionStrings["db_Mysql"].ConnectionString);
        }

        protected AbstractRepository(string dbConnection)
        {
            db = new MySqlConnection(ConfigurationManager.ConnectionStrings[dbConnection].ConnectionString);
        }

        public void Dispose()
        {
            if(db != null)
                db.Dispose();
        }

    }
}
