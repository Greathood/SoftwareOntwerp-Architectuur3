using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Models.Sprints;
using SOA3.Models.Users;
using SOA3.States.SprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.UnitTest
{
    [TestClass]
    public class ProductOwnerTest
    {
        private readonly ProductOwner _productOwner;
        private readonly Project _project;
        public ProductOwnerTest()
        {
            _productOwner = new ProductOwner();
            _project = new Project(_productOwner, "big project", "this is our biggest project yet");
        }

        [TestMethod]
        public void addSprintTest()
        {
            ScrumMaster scrumMaster = new ScrumMaster();
            var sprint = new Sprint("sprint uno", DateTime.Now, DateTime.Now.AddDays(7), scrumMaster);
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
    }
}
