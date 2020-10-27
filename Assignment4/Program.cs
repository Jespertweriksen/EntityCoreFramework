
using System;
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
        }
    }
}