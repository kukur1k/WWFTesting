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
        private List<DevProject> Projects;
        
        [SetUp]
        public void Setup()
        {
            DevProject.ResetID();
           
            proj = new Projects();
            proj.DevProjects = new List<DevProject>
            {
                new DevProject("Proj1", "Ivanov", Status.Create, 1),
                new DevProject("ProjLearn", "Petrov", Status.InWork, 1),
                new DevProject("TeamWork", "Petrovskiy", Status.Create, 2)
            };
        }

        [Test]
        public void AddProjects()
        {
            int oldCount = proj.DevProjects.Count;

            var newProj = new DevProject("NewProj", "Sidorenko", Status.Create, 1);

            proj.DevProjects.Add

            proj.DevProjects.Add(newProj);

            Assert.That(proj.DevProjects.Count, Is.EqualTo(oldCount+1));
            Assert.That(proj.DevProjects.Last().Name, Is.EqualTo("NewProj"));
        }

        [Test]
        public void RemoveProjects()
        {
            int oldCount = proj.DevProjects.Count;
            string OldFirstName = proj.DevProjects[0].Name;

            var DevProj = proj.DevProjects.First();

            proj.DevProjects.Remove(DevProj);

            Assert.That(proj.DevProjects.Count, Is.EqualTo(oldCount-1));
            Assert.That(proj.DevProjects.First().Name, !Is.EqualTo("NewProj"));
            Assert.That(proj.DevProjects.First().Name, Is.EqualTo("ProjLearn"));
        }

        [Test]
        public void SearchBySubStr()
        {

            string search = "proj";

             proj.DevProjects.= 

            proj.DevProjects.Remove(DevProj);

            Assert.That(proj.DevProjects.Count, Is.EqualTo(oldCount - 1));
            Assert.That(proj.DevProjects.First().Name, !Is.EqualTo("NewProj"));
            Assert.That(proj.DevProjects.First().Name, Is.EqualTo("ProjLearn"));
        }

    }
}
