using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem13
    {
        public static void run()
        {
            Product product = new Product();
            var min = product.GetProducts().Min(p => p.ProMrp);

            Console.WriteLine($"Min Price : {min}");
        }
    }
}
