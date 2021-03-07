using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Models.Board;
using SOA3.Models.Users;
using SOA3.Services;
using System;

namespace SOA3.UnitTest
{
    [TestClass]
    public class ProjectTest
    {
        readonly Project project;

        public ProjectTest()
        {
            ProductOwner owner = new ProductOwner();
            project = new Project(owner, "test project", "");
        }

        [TestMethod]
        public void ConvertProjectToSoftwareProjectTest()
        {
            //Arrange
            IContentManagerFactory factory = new GitFactory();
            ContentManager gitContentManager = new ContentManager(factory);

            //Act
            gitContentManager.InitRepo("SOA3", project);
            var softProject = project.ConvertToSoftwareProject();
            softProject.AddRepo(gitContentManager.GetRepo());

            //Arrange
            Assert.IsTrue(softProject != null);
        }

        [TestMethod]
        public void AddKanbanBoardToProjectTest()
        {
            //Arrange
            KanbanBoard board = new KanbanBoard();

            //Act
            project.AddBoard(board);

            //Assert
            Assert.IsTrue(project.GetBoard() is KanbanBoard);
        }

        [TestMethod]
        public void AddScrumBoardToProjectTest()
        {
            //Arrange
            ScrumBoard board = new ScrumBoard();

            //Act
            project.AddBoard(board);

            //Assert
            Assert.IsTrue(project.GetBoard() is ScrumBoard);
        }

        [TestMethod]
        public void AddSprintToScrumBoard()
        {
            //Arrange
            ScrumBoard board = new ScrumBoard();
            ScrumMaster master = new ScrumMaster();
            Sprint sprint = new Sprint("sprint 1", DateTime.Now, DateTime.Now.AddDays(14), master);

            //Act
            project.AddBoard(board);
            project.AddSprint(sprint);

            //Assert
            Assert.IsTrue(project.GetBoard().getSprints().Count >= 1);
        }

        [TestMethod]
        public void AddBacklogItemToSprintTest()
        {
            //Arrange
            ScrumBoard board = new ScrumBoard();
            ScrumMaster master = new ScrumMaster();
            Sprint sprint = new Sprint("sprint 1", DateTime.Now, DateTime.Now.AddDays(14), master);
            Backlog backlog = new Backlog();
            BacklogItem backlogitem = new BacklogItem(backlog, "test", 8);

            //Act
            project.AddBoard(board);
            board.AddSprint(sprint);
            board.AddBacklogItem(backlogitem);

            //Assert
            Assert.IsNotNull(project.GetBoard().getSprints());
            Assert.IsTrue(sprint.backlog.backlogItems.Contains(backlogitem));
        }
    }
}
