
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
            ds.CreateCategory("Test","CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");

            var result = ctx.Orders.Where(o => o.Id == 1).Select(o => o.Id);

            foreach (var VARIABLE in ctx.Products)
            {
                Console.WriteLine(VARIABLE);
            }








        }
    }
}


