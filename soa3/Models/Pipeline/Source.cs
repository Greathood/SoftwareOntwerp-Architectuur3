using SOA3.Services.Pipeline;

namespace SOA3.Models.Pipeline
{
    class Source : IPipelineStep
    {
        //Activiteiten om de source code die gebouwd (en mogelijk getest en gedeployed) moet 
        //worden op te halen naar een context waarin de gehele pipeline wordt uitgevoerd.
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitSource(this);
        }
    }
}
