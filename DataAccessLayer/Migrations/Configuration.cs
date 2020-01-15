namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccessLayer.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new CustomizedMySqlMigrationSqlGenerator());
        }

        protected override void Seed(AccessLayer.DBContext context)
        {
            // SeedDB.Seed(dBContext);
        }
    }
}
