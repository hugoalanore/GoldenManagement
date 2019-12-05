using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessLayer.AccessLayer
{
    public partial class DGGoldenManagement : DbContext
    {
        public DGGoldenManagement() : base("db_Mysql")
        {
        }
    }
}
