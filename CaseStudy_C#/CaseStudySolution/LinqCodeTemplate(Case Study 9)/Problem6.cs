using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem6
    {
        public static void run()
        {
            Product product = new Product();
            var products = product.GetProducts();

            var result = products.OrderByDescending(p => p.ProMrp);

            foreach(var item in result)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }
        }
    }
}
