using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem14
    {
        
        public static void run()
        {
            Product product = new Product();

            bool allBelow30 = product.GetProducts().All(p => p.ProMrp < 30);
            Console.WriteLine("All below 30? "+allBelow30);
        }
    }
}
