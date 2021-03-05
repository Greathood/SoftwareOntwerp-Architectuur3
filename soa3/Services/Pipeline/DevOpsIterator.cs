using SOA3.Models.DevOps;
using SOA3.Models.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Services.Pipeline
{
    class DevOpsIterator : PipelineIterator
    {
        private List<IPipelineStep> pipelineSteps = new List<IPipelineStep>();
        private int currentPosition = -1;

        public DevOpsIterator()
        {
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

        public bool HasNext()
        {
            return currentPosition < pipelineSteps.Count()-1;
        }
    }
}
