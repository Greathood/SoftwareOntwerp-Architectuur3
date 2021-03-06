using SOA3.Models.Pipeline;
using System;

namespace SOA3.Services.Pipeline
{
    class DevOpsVisitor : IPipelineVisitor
    {
        public void VisitUtility(Utility utility)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running utility step");
        }

        public void VisitAnalyse(Analyse analyse)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running analyse step");
        }

        public void VisitBuild(Build build)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running build step");
        }

        public void VisitDeploy(Deploy deploy)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running deploy step");
        }

        public void VisitPackage(Package package)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running package step");
        }

        public void VisitSource(Source source)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running source step");
        }

        public void VisitTest(Test test)
        {
            Console.WriteLine("DEVOPS PIPELINE: Running Test step");
        }
    }
}
