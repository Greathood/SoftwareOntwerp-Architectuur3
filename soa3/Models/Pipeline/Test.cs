using SOA3.Services.Pipeline;

namespace SOA3.Models.Pipeline
{
    class Test : IPipelineStep
    {
        //Voert test uit, bv via NUnit, Selenium etc.Deze categorie bevat ook acties om test resultaten te publiceren, of coverage resultaten.
        public void Run(IPipelineVisitor visitor)
        {
            visitor.VisitTest(this);
        }
    }
}
