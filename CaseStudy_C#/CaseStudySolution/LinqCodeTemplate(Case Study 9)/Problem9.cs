using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem9
    {
        public static void run()
        {
            Product product = new Product();

            var result = product.GetProducts()
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .FirstOrDefault();

            Console.WriteLine("Highest priced FMCG: " + result.ProName +"Price: "+ result.ProMrp);
        }
    }
}
