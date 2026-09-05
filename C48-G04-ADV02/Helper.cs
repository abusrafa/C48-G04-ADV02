using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G04_ADV02
{
    public class Helper
    {
        public static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"--- {title} ---");
            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            Console.WriteLine();
        }

    }
}
