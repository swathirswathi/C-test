using Coding_Challenge___Order_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge___Order_Management_System.Interface
{
    internal interface IOrderManagementRepository
    {
        //void CreateOrder(User user, List<Product> products);
        int cancelOrder(int userId, int orderId);
        void createProduct(User user, Product product);
        void createUser(User user);
        List<Product> GetAllProducts();
        Orders getOrderByUser(int user_id);


    }
}
