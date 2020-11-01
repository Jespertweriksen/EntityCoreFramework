using System.Collections.Generic;

namespace Assignment4
{
    
        public interface IDataService
        {
            IList<Category> GetCategories();
            Category GetCategory(int id);
            Category CreateCategory(string name, string description);
            bool UpdateCategory(int id, string name, string description);
            Product GetProduct(int id);
            IList<Product> GetProductByCategory(int id);
            IList<Product> GetProductByName(string searchString);
            Order GetOrder(int id);
            bool DeleteCategory(int id);
            List<Order> GetOrders();
            List<OrderDetail> GetOrderDetailsByOrderId(int Id);
            List<OrderDetail> GetOrderDetailsByProductId(int id);
        }
    }
