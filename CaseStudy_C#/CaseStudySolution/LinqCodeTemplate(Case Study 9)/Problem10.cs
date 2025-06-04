using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem10
    {
        public static void run()
        {
            Product product = new Product();

            int count = product.GetProducts().Count();
            Console.WriteLine("Total Products: " + count);
        }
    }
}
