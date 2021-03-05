using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Package : IPipelineStep
    {
        //Met activiteiten in deze categorie kun je diverse (3rd party) packages/libraries installeren waar je eigen software afhankelijk van is.
        public void run()
        {
            Console.WriteLine("PIPELINE: Running package step");
        }
    }
}
