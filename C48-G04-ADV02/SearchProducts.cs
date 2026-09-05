using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G04_ADV02
{

    internal class SearchProducts
    {
        public static List<Product> SearchProduct(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> Result = new();

            foreach (Product p in products)
            {
                if (filter(p))
                {
                    Result.Add(p);
                }
            }
            return Result;
        }

        public static bool IsElectronics(Product p) => p.Category == "Electronics";
        public static bool IsCheaperThan50(Product p) => p.Price < 50;
        public static bool IsInStock(Product p) => p.Stock > 0;
        public static bool IsClothingUnder100(Product p) => p.Category == "Clothing" && p.Price < 100;

        #region 2. Print Report Logic (Task 3.1 - Action)

        public static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product p in products)
            {
                action(p);
            }
        }

        public static void PrintShort(Product p)
        {
            Console.WriteLine($"{p.Name} - ${p.Price}");
        }


        public static void PrintDetailed(Product p)
        {
            Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");
        }

        #endregion

        #region 3. Transform Logic (Task 3.2 - Func)

        
        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
        {
            List<string> result = new();

            foreach (Product p in products)
            {
                result.Add(transformer(p));
            }

            return result;
        }


        public static string FormatSummary(Product p)
        {
            return $"{p.Name} (${p.Price})";
        }

        public static string FormatPriceLabel(Product p)
        {
            if (p.Price > 100)
            {
                return $"{p.Name}: Expensive!";
            }
            else
            {
                return $"{p.Name}: Affordable";
            }
        }

        #endregion

        #region 4. Filter Logic (Task 3.3 - Predicate)

        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> match)
        {
            List<Product> result = new();

            foreach (Product p in products)
            {
                if (match(p))
                {
                    result.Add(p);
                }
            }

            return result;
        }


        public static bool IsLowStock(Product p) => p.Stock < 20;

        #endregion
    }


}
