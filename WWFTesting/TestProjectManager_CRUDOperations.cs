using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithTextFormat;

namespace WWFTesting
{
    public class TestProjectManager_CRUDOperations
    {
        private Projects proj;
        
        [SetUp]
        public void Setup()
        {
            DevProject.ResetID();
           
            proj = new Projects();
            proj.DevProjects = new List<DevProject>
            {
                new DevProject("Proj1", "Ivanov", Status.Create, 1),
                new DevProject("ProjLearn", "Petrov", Status.InWork, 1),
                new DevProject("TeamWork", "Petrovskiy", Status.Create, 2),
                new DevProject("Alpha", "ALead", Status.Success, 1),
            };
        }

        [Test]
        public void AddProjects()
        {
            int oldCount = proj.DevProjects.Count;
            var newProj = new DevProject("NewProj", "Sidorenko", Status.Create, 1);

            ServicesMethods.AddDevProject(proj, newProj);


            Assert.That(proj.DevProjects.Count, Is.EqualTo(oldCount+1));
            Assert.That(proj.DevProjects.Last().Name, Is.EqualTo("NewProj"));
        }

        [Test]
        public void RemoveProjects()
        {
            int oldCount = proj.DevProjects.Count;
            string OldFirstName = proj.DevProjects[0].Name;



            ServicesMethods.RemoveDevProject(1, proj);

            Assert.That(proj.DevProjects.Count, Is.EqualTo(oldCount-1));
            Assert.That(proj.DevProjects.First().Name, !Is.EqualTo("NewProj"));
            Assert.That(proj.DevProjects.First().Name, Is.EqualTo("ProjLearn"));
        }

        [Test]
        public void SearchBySubStr()
        {

            string search = "Proj";     
            List<DevProject> ResSearch = ServicesMethods.Search(search, proj.DevProjects);

            Assert.That(ResSearch[0].Name, Is.EqualTo("Proj1"));
            Assert.That(ResSearch[1].Name, Is.EqualTo("ProjLearn"));
            Assert.That(ResSearch.Count, Is.EqualTo(2));
        }

        [Test]
        public void SortByName()
        {

 
            int oldCount = proj.DevProjects.Count;

            List<DevProject> ResSearch = ServicesMethods.Sort(proj.DevProjects, "Name");


            Assert.That(ResSearch[0].Name, Is.EqualTo("Alpha"));
            Assert.That(ResSearch[1].Name, Is.EqualTo("Proj1"));
            Assert.That(ResSearch[2].Name, Is.EqualTo("ProjLearn"));
            Assert.That(ResSearch[3].Name, Is.EqualTo("TeamWork"));

        }

        [Test]
        public void SortByLeader()
        {

            int oldCount = proj.DevProjects.Count;

            List<DevProject> ResSearch = ServicesMethods.Sort(proj.DevProjects, "Leader");


            Assert.That(ResSearch[0].Leader, Is.EqualTo("ALead"));
            Assert.That(ResSearch[1].Leader, Is.EqualTo("Ivanov"));
            Assert.That(ResSearch[2].Leader, Is.EqualTo("Petrov"));
            Assert.That(ResSearch[3].Leader, Is.EqualTo("Petrovskiy"));

        }

        [Test]
        public void SortByPriority()
        {

   
            int oldCount = proj.DevProjects.Count;

            List<DevProject> ResSearch = ServicesMethods.Sort(proj.DevProjects, "Priority");


            Assert.That(ResSearch[0].Name, Is.EqualTo("Proj1"));
            Assert.That(ResSearch[1].Name, Is.EqualTo("ProjLearn"));
            Assert.That(ResSearch[2].Name, Is.EqualTo("Alpha"));
            Assert.That(ResSearch[3].Name, Is.EqualTo("TeamWork"));

        }

        [Test]
        public void UpdateProject()
        {
            ServicesMethods.UpdateDevProject(1, proj, "New", "NewLead", Status.Success, 2);

            Assert.That(proj.DevProjects[0].Name, Is.EqualTo("New"));
            Assert.That(proj.DevProjects[0].Leader, Is.EqualTo("NewLead"));
            Assert.That(proj.DevProjects[0].Status, Is.EqualTo(Status.Success));
            Assert.That(proj.DevProjects[0].Priority, Is.EqualTo(2));


        }



    }
}
