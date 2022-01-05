namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Interestellar', 1, '06/11/2014', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Hangover', 5, '06/11/2009', 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Shrek', 5, '22/06/2001', 11)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Movies WHERE Name = 'Interestellar'");
            Sql("DELETE FROM Movies WHERE Name = 'Hangover'");
            Sql("DELETE FROM Movies WHERE Name = 'Shrek'");
        }
    }
}
