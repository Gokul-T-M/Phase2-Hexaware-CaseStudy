using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem12
    {
        public static void run()
        {
            Product product = new Product();
            var max = product.GetProducts().Max(p=>p.ProMrp);

            Console.WriteLine($"Max Price : {max}");
        }
    }
}
