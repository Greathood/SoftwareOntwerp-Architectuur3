using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA3.Models.Forum;
using SOA3.Models.Sprints;
using SOA3.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOA3.UnitTest
{
    /// <summary>
    /// Summary description for ForumTest
    /// </summary>
    [TestClass]
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

        [TestMethod]
        public void addComment()
        {
            // Arrange
            ProductOwner productOwner = new ProductOwner();
            Comment comment = new Comment("this doesn't work", productOwner);

            // Act
            var result = _thread.addComment(comment);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
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
            Assert.IsFalse(result);
        }
    }
}
