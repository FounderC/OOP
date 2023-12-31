using КР.Repository;
using КР.Repository.Base;
using КР.Service;

namespace КР.Initializers
{
    public class ServicesInitializer
    {
        public static IOrderRepository OrderRepository { get; } = new OrderRepository();
        public static IProductRepository ProductRepository { get; } = new ProductRepository();
        public static IUserRepository UserRepository { get; } = new UserRepository();

        public static ProductService ProductService { get; } = new ProductService(ProductRepository);
        public static UserService UserService { get; } = new UserService(UserRepository);

        public static OrderService OrderService { get; } =
            new OrderService(OrderRepository, UserService, ProductService);
    }
}