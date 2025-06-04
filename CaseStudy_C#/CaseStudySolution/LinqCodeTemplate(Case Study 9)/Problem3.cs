using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem3
    {
        public static void run()
        {
            Product product = new Product();
            var products = product.GetProducts();
             
            var result = products.OrderBy(p => p.ProCode);
            Console.WriteLine("Sorted by ProductCode:");
            
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");
            }
        }
    }
}
