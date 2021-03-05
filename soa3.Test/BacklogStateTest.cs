using SOA3.Models;
using SOA3.States.BacklogState;
using System;
using Xunit;

namespace states.Test
{
    //TODO: Write Test for DoingBackLogState with activities
    public class BacklogStateTest
    {
        private readonly BacklogItem _backlogItem1;
        
        public BacklogStateTest()
        {
            var scrumMaster = new ScrumMaster();
            var sprint = new Sprint("Sprint 1", new DateTime(), new DateTime().AddDays(7), scrumMaster);
            _backlogItem1 = new BacklogItem(sprint.backlog, "mn leuke item", 18);
            sprint.backlog.addBacklogItem(_backlogItem1);
        }
        
        [Fact]
        public void backlogItemStateHappyPath()
        {
            //Act
            _backlogItem1.backlogState.doing();
            
            // Assert (Can't go back to doing)
            Assert.True(_backlogItem1.backlogState is DoingBacklogState);
            
            // Act
            _backlogItem1.backlogState.done();
            
            // Assert
            Assert.True(_backlogItem1.backlogState is DoneBacklogState);
        }
        
        [Fact]
        public void backlogItemStateTodoToDone()
        {
            //Arrange
            _backlogItem1.backlogState.todo();
            
            //Act
            _backlogItem1.backlogState.done();
            
            // Assert (Can't go back to doing)
            Assert.True(_backlogItem1.backlogState is TodoBacklogState);
            Assert.False(_backlogItem1.backlogState is DoneBacklogState);
        }
        
        [Fact]
        public void backlogItemStateDoneToDoing()
        {
            // Arrange
            _backlogItem1.backlogState.doing();
            _backlogItem1.backlogState.done();
            
            // Act
            _backlogItem1.backlogState.doing();
            
            // Assert (Can't go back to doing)
            Assert.True(_backlogItem1.backlogState is DoneBacklogState);
            Assert.False(_backlogItem1.backlogState is DoingBacklogState);
        }
        
        // This one sometimes fails because the Dictionary returns an exception with
        // "An item with the same key has already been added."
        [Fact]
        public void backlogItemStateDoneToTodo()
        {
            // Arrange
            _backlogItem1.backlogState.doing();
            _backlogItem1.backlogState.done();
            
            // Act
            _backlogItem1.backlogState.todo();
            
            // Assert
            Assert.True(_backlogItem1.backlogState is TodoBacklogState);
        }
    }
}