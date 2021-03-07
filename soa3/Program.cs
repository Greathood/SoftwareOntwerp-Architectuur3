using System;
using System.Diagnostics.CodeAnalysis;

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
