using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Assignment4
{
    public class Order
    {
        [Key] public int Id { get; set; }
        public DateTime Date { get; set; }

        public DateTime Required { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public string ShipName { get; set; }

        public string ShipCity { get; set; }
        
        public override string ToString()
        {
            string ret =
                $"Id = {Id}, DateTime = {Date}, Required = {Required}, shipName= {ShipName}, Shipcity = {ShipCity}";

            return ret;
        }
    }
}