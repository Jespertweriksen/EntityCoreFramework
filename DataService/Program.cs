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
            

        }
    }
}