using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            MobilePhoneTestingApp app = new MobilePhoneTestingApp();
            Console.WriteLine("Run Test 1");
             app.RunApp();

            Console.WriteLine("Run Test 2");
            app.RunAppAsync();

            Console.Read();
        }
    }
}
