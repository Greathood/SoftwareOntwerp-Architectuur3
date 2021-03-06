using SOA3.Models.Pipeline;
using SOA3.Services.Pipeline;
using System;

namespace SOA3.Models.Pipeline
{
    class Analyse : IPipelineStep
    {
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitAnalyse(this);
        }
    }
}
