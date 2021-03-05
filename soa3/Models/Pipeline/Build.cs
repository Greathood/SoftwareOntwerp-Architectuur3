using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Build : IPipelineStep
    {
        //Dit zijn acties die je software builden en linken. Naast .NET en .NET Core builds worden diverse andere builds ondersteund, 
        //zoals Maven, Ant, maar ook een build job via Jenkins. 
        public void run()
        {
            Console.WriteLine("PIPELINE: Running build step");
        }
    }
}
