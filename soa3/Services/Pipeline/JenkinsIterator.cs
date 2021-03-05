using SOA3.Models.Pipeline;
using System;

namespace SOA3.Services.Pipeline
{
    class JenkinsIterator : PipelineIterator
    {
        public IPipelineStep GetNext()
        {
            throw new NotImplementedException();
        }

        public bool HasNext()
        {
            throw new NotImplementedException();
        }
    }
}
