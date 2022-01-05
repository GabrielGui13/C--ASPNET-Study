using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
    public class EFContext : IdentityDbContext<ApplicationUser>
    {
        public EFContext() : base(Connection.connectString) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public static EFContext Create()
        {
            return new EFContext();
        }
    }
}