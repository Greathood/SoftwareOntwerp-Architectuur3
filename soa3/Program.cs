using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        
        static void Main(string[] args)
        {
            Run run = new Run();

            run.run();

            Console.ReadKey();
        }
    }
}
