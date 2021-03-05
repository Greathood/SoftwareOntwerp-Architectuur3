using System;
using SOA3.Models;
using SOA3.Models.Users;
using SOA3.States.SprintState;
using Xunit;

namespace SOA3.Test
{
    public class SprintTest
    {
        private readonly SprintState _sprintState;
        private readonly Sprint _sprint;
        private readonly BacklogItem _backlogItem1;
        
        public SprintTest()
        {
            var scrumMaster = new ScrumMaster();
            _sprint = new Sprint("Sprint 1", new DateTime(), new DateTime().AddDays(7), scrumMaster);
            _backlogItem1 = new BacklogItem(_sprint.backlog, "mn leuke item", 18);
            scrumMaster.addSprint(_sprint);
            _sprint.sprintState.start();
            _sprint.backlog.addBacklogItem(_backlogItem1);
        }

        [Fact]
        public void sprintPathTest()
        {
            _sprint.sprintState.start();
            Assert.True(_sprint.sprintState is ActiveSprintState);
            
            _sprint.sprintState.startReview();
            Assert.True(_sprint.sprintState is ReviewSprintState);
            
            _sprint.sprintState.close();
            Assert.True(_sprint.sprintState is ClosedSprintState);
            
            _sprint.sprintState.finish();
            Assert.True(_sprint.sprintState is FinishedSprintState);
        }
        
        [Fact]
        public void addTeamMemberTest()
        {
            // Arrange
            Developer dev1 = new Developer();
            Developer dev2 = new Developer();
            Developer dev3 = new Developer();
            ScrumMaster scrum = new ScrumMaster();
            
            // Act
            
            _sprint.addTeamMember(dev1);
            _sprint.addTeamMember(dev2);
            _sprint.addTeamMember(dev3);
            _sprint.addTeamMember(scrum);
            
            _sprint.removeTeamMember(dev2);
            
            _backlogItem1.assign(dev1);
            _backlogItem1.backlogState.doing();
            _backlogItem1.backlogState.done();
            _sprint.backlog.updateBacklogITem(_backlogItem1);
            
            // Assert
            Assert.True(_sprint.getTeam().Count == 3);
            Assert.True(
                _sprint.getTeam().ContainsKey(dev1) &&
                            _sprint.getTeam().ContainsKey(dev3) &&
                            _sprint.getTeam().ContainsKey(scrum)
                );
        }
    }
}