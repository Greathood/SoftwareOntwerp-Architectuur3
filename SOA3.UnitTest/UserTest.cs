using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Models.Board;
using SOA3.Models.Users;
using SOA3.States.SprintState;
using System;
using System.Linq;

namespace SOA3.UnitTest
{
    [TestClass]
    public class UserTest
    {
        private readonly ProductOwner _productOwner;
        private readonly ScrumMaster _scrumMaster;
        private readonly Project _project;
        public UserTest()
        {
            _productOwner = new ProductOwner();
            _scrumMaster = new ScrumMaster();
            _project = new Project(_productOwner, "big project", "this is our biggest project yet");
        }

        [TestMethod]
        public void AddSprintToProductOwnerTest()
        {
            //Arrange
            var sprint = new Sprint("sprint uno", DateTime.Now, DateTime.Now.AddDays(7), _scrumMaster);
            ActiveSprintState sprintState = new ActiveSprintState();

            // Act
            sprint.setState(sprintState);
            sprintState.startReview();
            _productOwner.addSprint(sprint);
            sprint.setState(sprintState);

            // Assert
            Assert.IsTrue(_productOwner.getSprints().Count == 1);
            Assert.IsTrue(_productOwner.getSprints().First().Equals(sprint));
        }

        [TestMethod]
        public void AddSprintToScrumMasterTest()
        {
            //Arrange
            var sprint = new Sprint("sprint uno", DateTime.Now, DateTime.Now.AddDays(7), _scrumMaster);
            ActiveSprintState sprintState = new ActiveSprintState();

            //Act
            sprint.setState(sprintState);
            sprintState.startReview();
            _scrumMaster.addSprint(sprint);
            sprint.setState(sprintState);

            //Assert
            Assert.IsTrue(_scrumMaster.getSprints().Contains(sprint));
        }
    }
}
