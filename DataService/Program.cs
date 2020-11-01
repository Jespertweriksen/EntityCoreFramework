using System;
//using System.Data.Entity;
using System.Linq;
using Assignment4;
using Microsoft.EntityFrameworkCore;


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
                join s1 in ctx.Products on s.productid equals s1.Id
                where m.Id == 10248
                select new  {
                    Id = m.Id,
                    OrderDetails = m.OrderDetails,
                    Name = s1.Name
                }).ToList().FirstOrDefault();
            
            var query2 = ctx.Orders.Where(o => o.Id == 10248)
                .Select(a => new Order
                {
                    Id = a.Id,
                    OrderDetails = a.OrderDetails
                }).FirstOrDefault();

            var query = ctx.Orders.AsQueryable().Where(o => o.Id == 10248).FirstOrDefault();
            
            var query3 = ctx.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(d => d.Product)
                .AsEnumerable()
                .FirstOrDefault(o => o.Id == 10248);
            
            Console.WriteLine(($"her er objektet: {query.OrderDetails}"));

            foreach (var VARIABLE in query3.OrderDetails)
            {
                Console.WriteLine(VARIABLE);
            }
            

            
           


        }
    }
}