using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Source : IPipelineStep
    {
        //Activiteiten om de source code die gebouwd (en mogelijk getest en gedeployed) moet 
        //worden op te halen naar een context waarin de gehele pipeline wordt uitgevoerd.
        public void run()
        {
            Console.WriteLine("PIPELINE: Running sources step");
        }
    }
}
