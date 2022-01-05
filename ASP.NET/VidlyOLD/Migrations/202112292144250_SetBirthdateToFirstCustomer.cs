namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdateToFirstCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1980-01-01 23:59:59.999' WHERE Name = 'John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
