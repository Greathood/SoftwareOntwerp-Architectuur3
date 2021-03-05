using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Deploy : IPipelineStep
    {
        //Bevat acties om deployment op bv Azure uit te voeren.
        public void run()
        {
            Console.WriteLine("PIPELINE: Running deploy step");
        }
    }
}
