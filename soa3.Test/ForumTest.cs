using SOA3.Models;
using SOA3.Models.Forum;
using System;
using Xunit;

namespace SOA3.Test
{
    public class ForumTest
    {
        private readonly BacklogItem _backlogItem;
        private readonly Thread _thread;
        
        public ForumTest()
        {
            Backlog backlog = new Backlog();
            Developer dev = new Developer();
            ScrumMaster scrumMaster = new ScrumMaster();
            Sprint sprint = new Sprint("Sprint 1", new DateTime(), new DateTime().AddDays(7), scrumMaster);
            sprint.addTeamMember(dev);
            Forum forum = new Forum(sprint);
            _backlogItem = new BacklogItem(backlog, "a new item", 12);
            _thread = forum.addThread(_backlogItem, "there is a issue", "description", dev);
        }
        
        [Fact]
        public void addComment()
        {
            // Arrange
            ProductOwner productOwner = new ProductOwner();
            Comment comment = new Comment("this doesn't work", productOwner);
            
            // Act
            var result = _thread.addComment(comment);
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void addCommentToDone()
        {
            // Arrange
            _backlogItem.backlogState.doing();
            _backlogItem.backlogState.done();
            ProductOwner productOwner = new ProductOwner();
            Comment comment = new Comment("this doesn't work", productOwner);
            
            // Act
            var result = _thread.addComment(comment);
            
            // Assert
            Assert.False(result);
        }
    }
}