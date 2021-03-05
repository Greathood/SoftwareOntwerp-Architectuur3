namespace SOA3.Services.Pipeline
{
    class PipelineRunner
    {
        public void StartPipeline(PipelineIterator iterator)
        {
            while (iterator.HasNext())
            {
                var step = iterator.GetNext();
                step.run();
            }
        }
    }
}
