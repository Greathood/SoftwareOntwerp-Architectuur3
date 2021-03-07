using SOA3.Models.Pipeline;

namespace SOA3.Services.Pipeline
{
    interface PipelineIterator
    {
        IPipelineStep GetNext();
        bool HasNext();

        IPipelineVisitor GetVisitor();
    }
}
