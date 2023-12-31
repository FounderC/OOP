using КР.Service;

namespace КР.Initializers
{
    public class ProductInitializer
    {
        private ProductService _productService;

        public ProductInitializer(ProductService productService)
        {
            _productService = productService;
        }

        public void InitializeProducts()
        {
            _productService.AddProduct("Товар 1", 100m);
            _productService.AddProduct("Товар 2", 200m);
            _productService.AddProduct("Товар 3", 300m);
            _productService.AddProduct("Товар 4", 400m);
            _productService.AddProduct("Товар 5", 500m);
            _productService.AddProduct("Товар 6", 600m);
            _productService.AddProduct("Товар 7", 700m);
            _productService.AddProduct("Товар 8", 800m);
        }
    }
}