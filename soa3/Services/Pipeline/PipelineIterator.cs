using SOA3.Models.Pipeline;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Services.Pipeline
{
    interface PipelineIterator
    {
        IPipelineStep GetNext();
        bool HasNext();
    }
}
