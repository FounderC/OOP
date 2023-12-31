using System;

namespace КР.Models
{
    public class Order
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
    }
}