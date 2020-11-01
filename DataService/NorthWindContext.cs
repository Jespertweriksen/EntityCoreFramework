 
using Assignment4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFExample
{
    public class NorthWindContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=Hcn27wzv");
            //optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderDetail> OrderDetail { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
            

            modelBuilder.Entity<OrderDetail>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Orderid).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetail>().Property(x => x.productid).HasColumnName("productid");
            modelBuilder.Entity<OrderDetail>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetail>().HasKey(o => new {o.Orderid, o.productid});
           



            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>()
                .HasMany(x => x.OrderDetails)
                .WithOne(x => x.Product).HasForeignKey(x => x.productid);
            
            base.OnModelCreating(modelBuilder);



        }
    }

    
}