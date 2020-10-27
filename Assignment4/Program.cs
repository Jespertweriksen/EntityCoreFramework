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

            var result = from m in ctx.Orders
                join s in ctx.OrderDetails on m.Id equals s.Orderid
                join s1 in ctx.Products on s.ProductId equals s1.Id
                where m.Id == 10248
                select new {m, s, s1};
            
            Order query = 

            foreach (var VARIABLE in result)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}