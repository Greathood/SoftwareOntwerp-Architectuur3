using System;
using System.Linq;
using SOA3.Models;
using SOA3.States.SprintState;
using Xunit;

namespace SOA3.Test
{
    public class ProductOwnerTest
    {
        private readonly ProductOwner _productOwner;
        private readonly Project _project;
        public ProductOwnerTest()
        {
            _productOwner = new ProductOwner();
            _project = new Project(_productOwner, "big project", "this is our biggest project yet");
        }
    
        [Fact]
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
            Assert.True(_productOwner.getSprints().Count == 1);
            Assert.True(_productOwner.getSprints().First().Equals(sprint));
        }
    }
}