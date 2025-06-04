using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem11
    {
        public static void run()
        {
            Product product = new Product();

            int count = product.GetProducts().Count(p => p.ProCategory == "FMCG");
            Console.WriteLine("FMCG Products: " + count);
        }
    }
}
