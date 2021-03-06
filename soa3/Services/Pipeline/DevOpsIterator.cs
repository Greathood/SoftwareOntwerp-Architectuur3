using SOA3.Models.Pipeline;
using System.Collections.Generic;
using System.Linq;

namespace SOA3.Services.Pipeline
{
    class DevOpsIterator : PipelineIterator
    {
        private readonly List<IPipelineStep> pipelineSteps = new List<IPipelineStep>();
        private int currentPosition = -1;
        private IPipelineVisitor visitor;

        public DevOpsIterator()
        {
            visitor = new DevOpsVisitor();
            pipelineSteps.Add(new Source());
            pipelineSteps.Add(new Build());
            pipelineSteps.Add(new Test());
            pipelineSteps.Add(new Analyse());
            pipelineSteps.Add(new Package());
            pipelineSteps.Add(new Deploy());
            pipelineSteps.Add(new Utility());

        }
        public IPipelineStep GetNext()
        {
            if (HasNext())
            {
                currentPosition++;
                return pipelineSteps[currentPosition];
            }
            return null;
        }

        public IPipelineVisitor GetVisitor()
        {
            return visitor;
        }

        public bool HasNext() => currentPosition < pipelineSteps.Count - 1;
    }
}
