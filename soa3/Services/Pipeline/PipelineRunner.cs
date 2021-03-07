
namespace SOA3.Services.Pipeline
{
    class PipelineRunner
    {

        public PipelineIterator Iterator { get; }

        public PipelineRunner(PipelineIterator iterator)
        {
            this.Iterator = iterator;
        }

        public void StartPipeline()
        {
            while (Iterator.HasNext())
            {
                var step = Iterator.GetNext();
                step.Run(Iterator.GetVisitor());
            }
        }
    }
}
