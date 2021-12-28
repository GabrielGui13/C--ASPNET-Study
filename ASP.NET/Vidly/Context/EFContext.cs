using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.Configuration;

namespace Vidly.Context
{
    // enable-migrations
    // add-migration MigrationName
    // update-database
    // update-database -TargetMigration $InitialDatabase
    // update-database -TargetMigration MigrationName
    public class Connection
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["VidlyContext"].ConnectionString;
    }
    public class EFContext : DbContext
    {

        public EFContext() : base(Connection.connectString) { }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Movie> movie { get; set; }
    }
}