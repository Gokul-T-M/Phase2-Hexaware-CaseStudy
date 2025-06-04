using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem8
    {
        public static void run()
        {
            Product product = new Product();
            var result = product.GetProducts().GroupBy(p=>p.ProMrp);

            foreach(var item in result)
            {
                Console.WriteLine(item.Key+" : ");

                foreach(var pro in item)
                {
                    Console.WriteLine($" -- {pro.ProName}\t{pro.ProMrp}");
                }
            }
        }
    }
}
