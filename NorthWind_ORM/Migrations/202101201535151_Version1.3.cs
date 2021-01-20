namespace NorthWind_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version13 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Northwind.Regions", newName: "Region");
            AddColumn("Northwind.Customers", "FoundationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("Northwind.Customers", "FoundationDate");
            RenameTable(name: "Northwind.Region", newName: "Regions");
        }
    }
}
