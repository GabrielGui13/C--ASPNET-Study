namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAddedFixingCheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            Sql($"UPDATE Movies SET DateAdded = {(DateTime.Now).ToString().Split(' ')[0]} WHERE Name = 'Matrix'"); //NAO FUNCIONA ESSA BOSTA
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
    }
}
