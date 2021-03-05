using SOA3.Models;
using SOA3.Models.Forum;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOA3.Models.SCM;
using SOA3.Models.SCM.Git;
using SOA3.Models.SCM.Mercury;
using SOA3.Services;
using SOA3.Services.Pipeline;

namespace SOA3
{
    [ExcludeFromCodeCoverage]
    class Run 
    {
        public void run()
        {
            ScrumMaster scrumMaster = new ScrumMaster();
            scrumMaster.FirstName = "Jack-Ryan";
            ProductOwner productOwner = new ProductOwner();
            Project project = new Project(productOwner, "project 1", "this is project 1");

            Sprint sprint1 = new Sprint("Sprint 1", new DateTime(), new DateTime().AddDays(7), scrumMaster);
            sprint1.addTeamMember(scrumMaster);

            Forum forum = new Forum(sprint1);
            scrumMaster.addSprint(sprint1);
            productOwner.addSprint(sprint1);

            //lets start the sprint
            sprint1.sprintState.start();

            BacklogItem backlogItem1 = new BacklogItem(sprint1.backlog, "mn leuke item", 18);
            backlogItem1.Subscribe(scrumMaster);
            backlogItem1.assign(scrumMaster);
            sprint1.backlog.addBacklogItem(backlogItem1);
            Thread thread = forum.addThread(backlogItem1, "een probleem ivm iets", "bla bla", scrumMaster);
            thread.addComment(new Comment("klopt", scrumMaster));


            sprint1.backlog.addBacklogItem(backlogItem1);
            backlogItem1.backlogState.doing();
            System.Threading.Thread.Sleep(100);
            backlogItem1.backlogState.done();
            System.Threading.Thread.Sleep(100);

            //should throw error, only going back from done to todo is allowed, not done to doing
            backlogItem1.backlogState.doing();
            thread.addComment(new Comment("backlogitem is gesloten dus men zou geen notificatie moeten krijgen..", scrumMaster));

            System.Threading.Thread.Sleep(100);

            backlogItem1.backlogState.todo();
            thread.addComment(new Comment("backlogitem is weer geopend dus men krijgt weer notificatie", scrumMaster));
            System.Threading.Thread.Sleep(100);

            backlogItem1.backlogState.doing();
            System.Threading.Thread.Sleep(100);

            backlogItem1.backlogState.done();

            Console.WriteLine(new Report(sprint1).reportAsString());
            
            Console.WriteLine("------------------------------------------------");
            

            // Abstract Factory
            GitFactory gitFactory = new GitFactory();
            ContentManager gitContentManager = new ContentManager(gitFactory);
            gitContentManager.InitRepo("project1", project);
            var currentBranch = gitContentManager.GetRepo().Branches.First();
            gitContentManager.AddCommit(currentBranch, "init commit", "");
            Console.WriteLine("");
            gitContentManager.AddCommit(currentBranch, "second Commit", "its okay I guess");
            gitContentManager.GetRepo().Branches.First().PrintCommits();


            DevOpsIterator devOps = new DevOpsIterator();
            PipelineRunner pipeline = new PipelineRunner();

            pipeline.StartPipeline(devOps);

            Console.ReadLine();
            
        }
    }
}
