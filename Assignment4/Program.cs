using System;
using System.Data.Entity;
using System.Linq;
using Assignment4;


namespace EFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new NorthWindContext();
            var ds = new DataService();
            ds.CreateCategory("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");

            var result = (from m in ctx.Orders
                join s in ctx.OrderDetail on m.Id equals s.Orderid
                join s1 in ctx.Products on s.ProductId equals s1.Id
                where m.Id == 10248
                select new  {
                    Id = m.Id,
                    OrderDetails = m.OrderDetails,
                    Name = s1.Name
                }).ToList().FirstOrDefault();

            var query = ctx.Orders.Where(o => o.Id == 10248).FirstOrDefault();
            
            Console.WriteLine(($"her er objektet: {query.OrderDetails}"));

            foreach (var VARIABLE in query.OrderDetails)
            {
                Console.WriteLine(VARIABLE);
            }
            
            Console.WriteLine(result);

            
           


        }
    }
}