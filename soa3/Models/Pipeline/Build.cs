using SOA3.Services.Pipeline;

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
