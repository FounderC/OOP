using System.Collections.Generic;
using System.Linq;
using КР.Models;
using КР.Repository.Base;

namespace КР.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProduct(string productName)
        {
            return _products.FirstOrDefault(p => p.Name == productName);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(_products);
        }
    }
}