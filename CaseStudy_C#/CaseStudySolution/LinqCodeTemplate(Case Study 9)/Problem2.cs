﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Problem2
    {
        public static void run()
        {
            Product product = new Product();
            var products = product.GetProducts();

            var result = products.Where(p => p.ProCategory == "Grain").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
        }
    }
}
