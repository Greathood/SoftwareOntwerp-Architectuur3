using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Models.Board;
using SOA3.Models.SCM.Git;
using SOA3.Models.SCM.Mercury;
using SOA3.Models.Users;
using SOA3.Services;
using System.Linq;

namespace SOA3.UnitTest
{
    /// <summary>
    /// Summary description for SCMTest
    /// </summary>
    [TestClass]
    public class SCMTest
    {
        private IContentManagerFactory factory;
        private Project project;
        public SCMTest()
        {
            project = new Project(  new ProductOwner(),
                                    "SOA3",
                                    "SOA3 eindopdracht");
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGitRepo()
        {
            //Arrange
            factory = new GitFactory();
            ContentManager gitContentManager = new ContentManager(factory);

            //Act
            gitContentManager.InitRepo("SOA3", project);
            var repo = gitContentManager.GetRepo();
            gitContentManager.AddCommit(repo.Branches.First(), "init commit", "this is the first commit");
            

            //Assert
            Assert.IsTrue(repo is GitRepo);
            //Check if we added the initial branch
            Assert.IsTrue(repo.Branches.Count == 1);
            Assert.IsNotNull(repo.FindCommit("init commit"));
        }

        [TestMethod]
        public void TestMercuryRepo()
        {
            //Arrange
            factory = new MercuryFactory();
            ContentManager mercuryContentManager = new ContentManager(factory);

            //Act
            mercuryContentManager.InitRepo("SOA3", project);
            var repo = mercuryContentManager.GetRepo();
            mercuryContentManager.AddCommit(repo.Branches.First(), "init commit", "this is the first commit");


            //Assert
            Assert.IsTrue(repo is MercuryRepo);
            Assert.IsTrue(repo.Branches.Count == 1);
        }
    }
}
