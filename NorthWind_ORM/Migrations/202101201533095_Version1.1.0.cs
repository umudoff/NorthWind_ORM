namespace NorthWind_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version110 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionID = c.Int(nullable: false),
                        RegionDescription = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        TerritoryID = c.String(nullable: false, maxLength: 20),
                        TerritoryDescription = c.String(nullable: false, maxLength: 50, fixedLength: true),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryID)
                .ForeignKey("dbo.Regions", t => t.RegionID)
                .Index(t => t.RegionID);
            
            AddColumn("Northwind.Employees", "Territory_TerritoryID", c => c.String(maxLength: 20));
            CreateIndex("Northwind.Employees", "Territory_TerritoryID");
            AddForeignKey("Northwind.Employees", "Territory_TerritoryID", "dbo.Territories", "TerritoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Territories", "RegionID", "dbo.Regions");
            DropForeignKey("Northwind.Employees", "Territory_TerritoryID", "dbo.Territories");
            DropIndex("dbo.Territories", new[] { "RegionID" });
            DropIndex("Northwind.Employees", new[] { "Territory_TerritoryID" });
            DropColumn("Northwind.Employees", "Territory_TerritoryID");
            DropTable("dbo.Territories");
            DropTable("dbo.Regions");
        }
    }
}
