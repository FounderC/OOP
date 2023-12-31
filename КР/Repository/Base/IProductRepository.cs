using System.Collections.Generic;
using КР.Models;

namespace КР.Repository.Base
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(string productName);
        List<Product> GetAllProducts();
    }
}