using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    class Program
    {
        public static void Main()
        {

            int choice;
            Console.WriteLine("Enter the problem number to run: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:Problem1.run(); break;
                case 2:Problem2.run(); break;
                case 3:Problem3.run(); break;
                case 4:Problem4.run(); break;
                case 5:Problem5.run(); break;
                case 6:Problem6.run(); break;
                case 7:Problem7.run(); break;
                case 8:Problem8.run(); break;
                case 9:Problem9.run(); break;
                case 10:Problem10.run(); break;
                case 11:Problem11.run(); break;
                case 12:Problem12.run(); break;
                case 13:Problem13.run(); break;
                case 14:Problem14.run(); break;
                case 15:Problem15.run(); break;
                
            }
            
        }
    }
}
