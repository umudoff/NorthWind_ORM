namespace NorthWind_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeCards",
                c => new
                    {
                        EmployeeCardId = c.Int(nullable: false, identity: true),
                        ExpiryDate = c.DateTime(),
                        CardHolderName = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeCardId)
                .ForeignKey("Northwind.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeCards", "EmployeeID", "Northwind.Employees");
            DropIndex("dbo.EmployeeCards", new[] { "EmployeeID" });
            DropTable("dbo.EmployeeCards");
        }
    }
}
