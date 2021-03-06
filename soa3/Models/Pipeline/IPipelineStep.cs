using SOA3.Services.Pipeline;

namespace SOA3.Models.Pipeline
{
    interface IPipelineStep
    {
        void Run(IPipelineVisitor visitor);
    }
}
