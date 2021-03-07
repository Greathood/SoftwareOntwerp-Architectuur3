using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Services.Pipeline;

namespace SOA3.UnitTest
{
    /// <summary>
    /// Summary description for PipelineTest
    /// </summary>
    [TestClass]
    public class PipelineTest
    {
        private readonly PipelineRunner pipeline;
        public PipelineTest()
        {
            PipelineIterator iterator = new DevOpsIterator();
            pipeline = new PipelineRunner(iterator);
        }

        [TestMethod]
        public void StartDevOpsPipeLine()
        {
            //Assert

            //Act
            pipeline.StartPipeline();

            //Assert
            Assert.IsTrue(pipeline.Iterator is DevOpsIterator);
            Assert.IsTrue(pipeline.Iterator.GetVisitor() is DevOpsVisitor);
        }
    }
}
