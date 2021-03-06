using SOA3.Models.Pipeline;
using SOA3.Services.Pipeline;
using System;

namespace SOA3.Models.Pipeline
{
    class Package : IPipelineStep
    {
        //Met activiteiten in deze categorie kun je diverse (3rd party) packages/libraries installeren waar je eigen software afhankelijk van is.
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitPackage(this);
        }
    }
}
