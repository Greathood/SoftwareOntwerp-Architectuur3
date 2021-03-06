using SOA3.Models.Pipeline;
using SOA3.Services.Pipeline;
using System;

namespace SOA3.Models.Pipeline
{
    class Build : IPipelineStep
    {
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitBuild(this);
        }
    }
}
