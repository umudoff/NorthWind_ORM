using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace NorthWind_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            int categoryId = 8;
            var context = new NorthWindContext();


            var orders = context.Orders.ToList();

            foreach (var o in orders)
            {
                var od = o.Order_Details.Where(c=>c.Product.CategoryID == categoryId);
                
                foreach (var d in od)
                {
                  //  Console.WriteLine(o.OrderID+" "+o.Customer.ContactName+" "+ d.Product.ProductName+" " +d.Quantity+" "+d.UnitPrice+" " +d.Product.Category.CategoryName);
                }
            }


            //Eager loading
            var res = context.Orders.Include(od => od.Order_Details.Select(d => d.Product)).Include(c => c.Customer).
                Where(o => o.Order_Details.All(p => p.Product.CategoryID == categoryId)).
                Select(t=> new { t.Customer.ContactName , details= t.Order_Details.
                         Select(n=> new { n.Product.ProductName, n.OrderID, n.UnitPrice, n.Quantity})}).ToList();
  
            foreach(var o in res)
            {
                foreach (var d in o.details)
                {
                    Console.WriteLine("Customer:"+o.ContactName+"; Product: "+d.ProductName+";  OrderID:"+d.OrderID+"; Quantity:"+d.Quantity+"; UnitPrice: "+d.UnitPrice);
                }
            }

           
            Console.ReadLine();
        }
    }
}
