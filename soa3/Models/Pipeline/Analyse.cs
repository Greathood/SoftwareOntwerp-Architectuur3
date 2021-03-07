using SOA3.Services.Pipeline;

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
