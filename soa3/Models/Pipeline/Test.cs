using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Test : IPipelineStep
    {
        //Voert test uit, bv via NUnit, Selenium etc.Deze categorie bevat ook acties om test resultaten te publiceren, of coverage resultaten.
        public void run()
        {
            Console.WriteLine("PIPELINE: Running test step");
        }
    }
}
