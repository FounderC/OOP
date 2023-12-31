using КР.Repository.Base;
using System.Collections.Generic;
using КР.Models;

namespace КР.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void AddProduct(string name, decimal price)
        {
            var product = new Product { Name = name, Price = price };
            _productRepository.AddProduct(product);
        }

        public Product GetProduct(string name)
        {
            return _productRepository.GetProduct(name);
        }
    }
}