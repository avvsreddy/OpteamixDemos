namespace CollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 23, 56, 12, 34, 78, 90, 11, 45 };

            numbers.Sort();

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }


            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Laptop", Price = 1200.00 },
                new Product() { Id = 2, Name = "Smartphone", Price = 800.00 },
                new Product() { Id = 3, Name = "Tablet", Price = 500.00 }
            };


            // Table Products
            // col: price

            // get all products order by price
            // SQL: SELECT * FROM Products ORDER BY Price

            var sortedProducts = products.OrderBy(p => p.Price).ToList(); // This will sort the products by price
            var sortedProductsDescending = products.OrderByDescending(p => p.Price).ToList(); // This will sort the products by price in descending order
            var bestway = from p in products
                          orderby p.Price descending
                          select p;



            products.Sort(new ProductPriceComparer()); // This will sort the products by price
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name}: ${product.Price}");
            }
        }

        class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }

        class Product// : IComparable<Product>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }

            //public int CompareTo(Product other)
            //{
            //     if(this.Price < other.Price)
            //    {
            //        return 1;
            //    }
            //    else if (this.Price > other.Price)
            //    {
            //        return -1;
            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
        }
    }
}
