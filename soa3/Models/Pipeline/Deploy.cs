using SOA3.Services.Pipeline;

namespace SOA3.Models.Pipeline
{
    class Deploy : IPipelineStep
    {
        //Bevat acties om deployment op bv Azure uit te voeren.
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitDeploy(this);
        }
    }
}
