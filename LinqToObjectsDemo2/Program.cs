namespace LinqToObjectsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Country { get; set; } = string.Empty;

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { ProductID = 1, Name = "Laptop",      Price = 999.99m, IsAvailable = true,  Country = "USA" },
                new Product { ProductID = 2, Name = "Smartphone",  Price = 699.50m, IsAvailable = true,  Country = "China" },
                new Product { ProductID = 3, Name = "Tablet",      Price = 399.00m, IsAvailable = false, Country = "South Korea" },
                new Product { ProductID = 4, Name = "Headphones",  Price = 199.99m, IsAvailable = true,  Country = "Germany" },
                new Product { ProductID = 5, Name = "Monitor",     Price = 249.75m, IsAvailable = true,  Country = "Japan" },
                new Product { ProductID = 6, Name = "Keyboard",    Price = 49.99m,  IsAvailable = true,  Country = "Taiwan" },
                new Product { ProductID = 7, Name = "Mouse",       Price = 29.99m,  IsAvailable = false, Country = "Malaysia" },
                new Product { ProductID = 8, Name = "Printer",     Price = 149.00m, IsAvailable = true,  Country = "USA" },
                new Product { ProductID = 9, Name = "Router",      Price = 89.95m,  IsAvailable = true,  Country = "China" },
                new Product { ProductID = 10, Name = "Webcam",     Price = 59.99m,  IsAvailable = false, Country = "Vietnam" }
            };
        }
    }
}
