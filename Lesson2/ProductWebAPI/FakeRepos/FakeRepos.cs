using ProductWebAPI.Models;

namespace ProductWebAPI.FakeRepos
{
    public static class FakeRepos
    {
        static public List<Models.Product> Products = new List<Models.Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500.50m },
            new Product { Id = 2, Name = "Mouse", Price = 25.99m },
            new Product { Id = 3, Name = "Keyboard", Price = 45.75m },
            new Product { Id = 4, Name = "Monitor", Price = 300.00m },
            new Product { Id = 5, Name = "Headphones", Price = 80.20m },
            new Product { Id = 6, Name = "Smartphone", Price = 1200.00m },
            new Product { Id = 7, Name = "Tablet", Price = 850.00m },
            new Product { Id = 8, Name = "USB Flash Drive", Price = 15.50m }
        };
    }
}
