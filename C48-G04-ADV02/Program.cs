namespace C48_G04_ADV02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSeparator.PrintSystemTitle();

            List<Product> catalog = new(){
    
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
              };


            #region Task01

            PrintSeparator.PrintSeparatorF();
            Console.WriteLine("------- Task01 -------");
            PrintSeparator.PrintSeparatorF();
            Console.WriteLine();

            // 1. All Electronics products
            List<Product> electronics = SearchProducts.SearchProduct(catalog, p => p.Category == "Electronics");
            Helper.PrintProducts("Electronics", electronics);
            Console.WriteLine();

            // 2. Products cheaper than $50
            List<Product> under50 = SearchProducts.SearchProduct(catalog, p => p.Price < 50);
            Helper.PrintProducts("Under $50", under50);
            Console.WriteLine();

            // 3. Products that are in stock (Stock > 0)
            List<Product> inStock = SearchProducts.SearchProduct(catalog, p => p.Stock > 0);
            Helper.PrintProducts("In Stock", inStock);
            Console.WriteLine();

            // 4. Clothing products under $100
            List<Product> clothingUnder100 = SearchProducts.SearchProduct(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Helper.PrintProducts("Clothing Under $100", clothingUnder100);

            #endregion

            #region Task 3.1 : Print Reports (Action)

            PrintSeparator.PrintSeparatorF();
            Console.WriteLine("------- Task 3.1 : Print Reports (Action) -------");
            PrintSeparator.PrintSeparatorF();
            Console.WriteLine();

            // Scenario 1: Short Report
            Console.WriteLine("--- Short Report ---");
            Action<Product> shortAction = SearchProducts.PrintShort;
            SearchProducts.PrintReport(catalog, shortAction);

            Console.WriteLine();

            // Scenario 2: Detailed Report
            Console.WriteLine("--- Detailed Report ---");
            Action<Product> detailedAction = SearchProducts.PrintDetailed;
            SearchProducts.PrintReport(catalog, detailedAction);

            #endregion

            Console.WriteLine();

            #region Task 3.2 : Transform Products (Func)

            PrintSeparator.PrintSeparatorF();
            Console.WriteLine("------- Task 3.2 : Transform Products (Func) -------");
            PrintSeparator.PrintSeparatorF();
            Console.WriteLine();

            // Scenario 3: Summary List
            Console.WriteLine("--- Summary List ---");
            Func<Product, string> summaryFunc = SearchProducts.FormatSummary;
            List<string> summaryList = SearchProducts.TransformProducts(catalog, summaryFunc);
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // Scenario 4: Price Labels
            Console.WriteLine("--- Price Labels ---");
            Func<Product, string> labelFunc = SearchProducts.FormatPriceLabel;
            List<string> labelList = SearchProducts.TransformProducts(catalog, labelFunc);
            foreach (var item in labelList)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Task 3.3 : Filter Products (Predicate)

            PrintSeparator.PrintSeparatorF();
            Console.WriteLine("------- Task 3.3 : Filter Products (Predicate) -------");
            PrintSeparator.PrintSeparatorF();
            Console.WriteLine();

            // Scenario 5: Low-Stock Alert (Stock < 20)
            Console.WriteLine("--- Low-Stock Alert ---");

            Predicate<Product> lowStockFilter = SearchProducts.IsLowStock;

            List<Product> lowStockItems = SearchProducts.FilterProducts(catalog, lowStockFilter);

            foreach (var item in lowStockItems)
            {
                Console.WriteLine($"[LOW STOCK] {item.Name}: only {item.Stock} left!");
            }

            #endregion

        }
    }

    

}
