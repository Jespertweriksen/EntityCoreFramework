using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Design;
using System.Threading.Channels;

namespace Assignment4
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        


        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, UnitPrice = {UnitPrice}, QuantityPerUnit = {QuantityPerUnit}, UnitsInStock = {UnitsInStock}, CategoryId = {CategoryId}, Category = {Category.Name}";
        }
        
    }
}