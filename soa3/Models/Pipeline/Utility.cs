using SOA3.Models.Pipeline;
using SOA3.Services.Pipeline;
using System;

namespace SOA3.Models.Pipeline
{
    class Utility : IPipelineStep
    {
        //Dit kunnen diverse acties zijn, die niet onder bovengenoemde categorieën vallen zoals het runnen van een batch script, 
        //files copiëren/deleten/downloaden, command line acties.
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitUtility(this);
        }
    }
}
