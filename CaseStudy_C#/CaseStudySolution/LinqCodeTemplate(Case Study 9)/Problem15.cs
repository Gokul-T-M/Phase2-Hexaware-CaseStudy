using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem15
    {
        public static void run()
        {
            Product product = new Product();

            bool anyBelow30 = product.GetProducts().Any(p=>p.ProMrp<30);
            Console.WriteLine("Any below 30? "+anyBelow30);
        }
    }

}
