using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem7
    {
        public static void run()
        {
            Product product = new Product();
            var result = product.GetProducts().GroupBy(p=>p.ProCategory);

            foreach (var group in result)
            {
                Console.WriteLine($"{group.Key} :");

                foreach(var value in group)
                {
                    Console.WriteLine($"-- {value.ProName}\t{value.ProCategory}");
                }
            }
        }
    }
}
