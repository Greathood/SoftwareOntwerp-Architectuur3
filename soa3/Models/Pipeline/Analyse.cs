using SOA3.Models.Pipeline;
using System;

namespace SOA3.Models.DevOps
{
    class Analyse : IPipelineStep
    {
        //Voor het analyseren van code via een externe tool als SonarQube. 
        //Sommige van deze tools hebben meerdere acties, zoals analysis preparation, analysis execution, analysis reporting.
        public void run()
        {
            Console.WriteLine("PIPELINE: Running analyse step");
        }
    }
}
