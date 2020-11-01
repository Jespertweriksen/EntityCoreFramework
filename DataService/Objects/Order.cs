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

        public string ShipName { get; set; }

        public string ShipCity { get; set; }


        [Required] public virtual IList<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();

            if (this.Id == 0)
            {
                OrderDetails = null;
                ShipCity = null;
                ShipName = null;
            }
        }

        public override string ToString()
        {
            string ret =
                $"Id = {Id}, DateTime = {Date}, Required = {Required}, shipName= {ShipName}, Shipcity = {ShipCity}";

            return ret;
        }
    }
}