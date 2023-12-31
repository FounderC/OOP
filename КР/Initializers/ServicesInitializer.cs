using КР.Repository;
using КР.Repository.Base;
using КР.Service;

namespace КР.Initializers
{
    public class ServicesInitializer
    {
        public IOrderRepository OrderRepository { get; } = new OrderRepository();
        public IProductRepository ProductRepository { get; } = new ProductRepository();
        public IUserRepository UserRepository { get; } = new UserRepository();

        public ProductService ProductService { get; }
        public UserService UserService { get; }
        public OrderService OrderService { get; }

        public ServicesInitializer()
        {
            ProductService = new ProductService(ProductRepository);
            UserService = new UserService(UserRepository);
            OrderService = new OrderService(OrderRepository, UserService, ProductService);
        }
    }
}