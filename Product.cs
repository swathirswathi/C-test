using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge___Order_Management_System.Model
{
    internal class Product
    {
        int productId;
        string productName;
        string description;
        double price;
        int quantityInStock;
        string type;
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int QuantityInStock
        {
            get { return quantityInStock; }
            set { quantityInStock = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        internal void Add(Product product)
        {
            throw new NotImplementedException();
        }
        //public Product(int productId, string productName,string description,double price,int quantityInStock,string type)
        //{
        //    ProductId = productId;
        //    ProductName = productName;
        //    Description = description;
        //    Price = price;
        //    QuantityInStock = quantityInStock;
        //    Type=type;
        //}

    }
}
