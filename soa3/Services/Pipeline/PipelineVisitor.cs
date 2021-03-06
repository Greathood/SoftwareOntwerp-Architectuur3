using SOA3.Models.Pipeline;


namespace SOA3.Services.Pipeline
{
    interface IPipelineVisitor
    {
        void VisitSource(Source source);
        void VisitBuild(Build build);
        void VisitTest(Test test);
        void VisitAnalyse(Analyse analyse);
        void VisitPackage(Package package);
        void VisitDeploy(Deploy deploy);
        void VisitUtility(Utility utility);
    }
}
