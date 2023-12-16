using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Coding_Challenge___Order_Management_System.Interface;
using Coding_Challenge___Order_Management_System.Model;
using Coding_Challenge___Order_Management_System.Utility;
using Coding_Challenge___Order_Management_System.Exception;
using System.Diagnostics;

namespace Coding_Challenge___Order_Management_System.Repository
{
    internal class OrderManagementRepository:IOrderManagementRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public OrderManagementRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        #region GetAllProducts 
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Products";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = (int)reader["ProductId"];
                        product.ProductName = (string)reader["ProductName"];
                        product.Description = (string)reader["Description"];
                        product.Price = (float)(double)reader["Price"];
                        product.QuantityInStock = (int)reader["QuantityInStock"];
                        product.Type = (string)reader["Type"];
                        product.Add(product);
                    }
                }
            }
            catch (NoDataFoundException nodataex)
            {
                Console.WriteLine("No data found");
            }

            return products;
        }
        #endregion

        #region createProduct
        public void createProduct(User user, Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Products(productId,productName,description,price,quantityInStock,type) values(@p_id,@p_name,@description,@price,@qual_in_stock,@type)";
                cmd.Parameters.AddWithValue("@p_id", product.ProductId);
                cmd.Parameters.AddWithValue("@p_name", product.ProductName);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price",product.Price);
                cmd.Parameters.AddWithValue(",@qual_in_stock", product.QuantityInStock);
                cmd.Parameters.AddWithValue("@type",product.Type);
               
                cmd.CommandText = "insert into Users(UserId,Username,Password,Role) values(@u_id,@u_name,@pw,@role)";
                cmd.Parameters.AddWithValue("@u_id", user.UserId);
                cmd.Parameters.AddWithValue("@u_name", user.Username);
                cmd.Parameters.AddWithValue("@pw", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
               
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int createProductStatus;
                try
                {
                    createProductStatus = cmd.ExecuteNonQuery();
                    Console.WriteLine(createProductStatus);
                    Console.WriteLine("Products and Users Added Successfully");
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("duplicate key value"))
                    {
                        Console.WriteLine($" already exists");
                    }

                }
            }
        }

        #endregion

        #region createUser(User user)
        public void createUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                cmd.CommandText = "insert into Users(UserId,Username,Password,Role) values(@u_id,@u_name,@pw,@role)";
                cmd.Parameters.AddWithValue("@u_id", user.UserId);
                cmd.Parameters.AddWithValue("@u_name", user.Username);
                cmd.Parameters.AddWithValue("@pw", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int createProductStatus;
                try
                {
                    createProductStatus = cmd.ExecuteNonQuery();
                    Console.WriteLine(createProductStatus);
                    Console.WriteLine("Products and Users Added Successfully");
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("duplicate key value"))
                    {
                        Console.WriteLine($" already exists");
                    }

                }
            }
        }

        #endregion

        #region getOrderByUser
        public Orders getOrderByUser(int user_id)
        {

            Orders order = new Orders();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Orders where UserID=@user_id";
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        order.OrderId = (int)reader["OrderId"];
                        order.UserId = (int)reader["UserId"];
                        order.ProductId = (int)reader["ProductId"];
                        order.OrderDate = (DateOnly)reader["OrderDate"];

                    }
                    return order;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region cancelOrder(int userId, int orderId) 
        public int cancelOrder(int userId,int orderId)
        {
            try
            {
                cmd.Parameters.Clear();
                var customerExists = getOrderByUser(userId);
                if (customerExists != null)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        cmd.CommandText = "delete from Orders where UserID=@u_id AND OrderID=@o_id";
                        cmd.Parameters.AddWithValue("@u_id", userId);
                        cmd.Parameters.AddWithValue("@o_id", orderId);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        int cancelOrderStatus = cmd.ExecuteNonQuery();
                        return cancelOrderStatus;
                    }

                }
                else
                {
                    throw new NoDataFoundException($" not found");
                }
            }
            catch (NoDataFoundException e)
            {
                Console.WriteLine($"Error :{e.Message}");
                return -1;
            }
        }

        #endregion
    }
}
