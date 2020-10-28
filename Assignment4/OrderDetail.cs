

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        
        [ForeignKey("orders")]
        public int Orderid { get; set; }
        
        [ForeignKey("products")]
        public int ProductId { get; set; }
        
        public int UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public int Discount { get; set; }

        public Product Product { get; set; }
        
        public override string ToString()
        {
            return
                $"OrderId = {Orderid}, Productid = {ProductId}";
        }

    }
}