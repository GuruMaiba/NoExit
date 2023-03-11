using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Configuration = NoExit.Migrations.Configuration;


namespace NoExit.Models
{
    public class DataEntity : DbContext
    {
        private class DataContextInitializer : MigrateDatabaseToLatestVersion<DataEntity, Configuration>
        {

        }

        public DataEntity()
            //: base(Properties.Settings.Default.ConnectionString){
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DataContextInitializer());
            //if (Database.Connection.State == ConnectionState.Closed)
            //{ Database.Initialize(force: false);
            //    Database.Connection.Open();
            //}
               
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataEntity>());
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataEntity>());
                //Database.SetInitializer(new DataContextInitializer());

                //if (Database.Connection.State == ConnectionState.Closed)
                //{
                //    Database.Initialize(force: true);
                //    Database.Connection.Open();

                //    //FillDbSample();
                //}
            }

        public DataEntity(string connectionString)
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DataContextInitializer());
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataEntity>());

            //if (Database.Connection.State == ConnectionState.Closed)
            //{
            //    Database.Initialize(force: false);
            //    Database.Connection.Open();

            //    //FillDbSample();
            //}
        }

        public DbSet<QuestRequest> QuestRequests { get; set; }
        public DbSet<Quest> Quests { get; set; }
    }
}
