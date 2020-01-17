namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.AccessLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new CustomizedMySqlMigrationSqlGenerator());
        }

        protected override void Seed(DBContext context)
        {
            //SeedDB.Seed();
        }
    }
}
