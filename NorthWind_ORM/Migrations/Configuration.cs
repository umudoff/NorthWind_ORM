namespace NorthWind_ORM.Migrations
{
    using NorthWind_ORM.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NorthWind_ORM.NorthWindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthWind_ORM.NorthWindContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
       
            Category c1 = new Category();
            Category c2 = new Category();
            c1.CategoryName ="Teas";
            c2.CategoryName ="Fruits";
            Region r1 = new Region();
            Region r2 = new Region();
            r1.RegionDescription = "Brno";
            r1.RegionID = 8;
            r2.RegionDescription = "Ostrava";
            r2.RegionID = 9;
            Territory t1 = new Territory();
            Territory t2 = new Territory();
            t1.TerritoryDescription ="Street 1";
            t2.TerritoryDescription = "Avenue 2";
            t1.RegionID =8;
            t2.RegionID = 9;

            context.Categories.AddOrUpdate(c => c.CategoryName,
               c1, c2);
            context.Regions.AddOrUpdate(r => r.RegionID, r1);
            context.Regions.AddOrUpdate(r => r.RegionID, r2);
            context.Territories.AddOrUpdate(t=> t.TerritoryID, t1);
            context.Territories.AddOrUpdate(t=>t.TerritoryID, t2);


        }
    }
}
