using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithTextFormat;

namespace WWFTesting
{
    public class TestProlectManager_ReadAndWrite
    {
        private WorkwithData<DevProject> dataHandler;
        private List<DevProject> Projects;
        private string filePath;



        [SetUp]
        public void Setup()
        {
            DevProject.ResetID();
            dataHandler = new WorkwithData<DevProject>();
            Projects = new List<DevProject>
            {
                new DevProject("Proj1", "Ivanov", Status.Create, 1),
                new DevProject("ProjLearn", "Petrov", Status.InWork, 1),
                new DevProject("TeamWork", "Petrovskiy", Status.Create, 2)
            };
        }


        //====================JSON================
        [Test]
        public void WriteAndReadOfJson()
        {
            filePath = "test.json";
            dataHandler.WriteToFile(Projects, filePath);

            var DataOfRead = dataHandler.ReadData(filePath);

            Assert.That(DataOfRead.Count, Is.EqualTo(Projects.Count));

            for (int i = 0; i < DataOfRead.Count; i++)
            {
                Assert.That(DataOfRead[i].Name, Is.EqualTo(Projects[i].Name));
                Assert.That(DataOfRead[i].Leader, Is.EqualTo(Projects[i].Leader));
                Assert.That(DataOfRead[i].Status, Is.EqualTo(Projects[i].Status));
                Assert.That(DataOfRead[i].Priority, Is.EqualTo(Projects[i].Priority));
            }

        }

        //====================XML================
        [Test]
        public void WriteAndReadOfXml()
        {
            filePath = "test.xml";
            dataHandler.WriteToFile(Projects, filePath);

            var DataOfRead = dataHandler.ReadData(filePath);

            Assert.That(DataOfRead.Count, Is.EqualTo(Projects.Count));

            for (int i = 0; i < DataOfRead.Count; i++)
            {
                Assert.That(DataOfRead[i].Name, Is.EqualTo(Projects[i].Name));
                Assert.That(DataOfRead[i].Leader, Is.EqualTo(Projects[i].Leader));
                Assert.That(DataOfRead[i].Status, Is.EqualTo(Projects[i].Status));
                Assert.That(DataOfRead[i].Priority, Is.EqualTo(Projects[i].Priority));
            }

        }

        //====================Yaml================
        [Test]
        public void WriteAndReadOfYaml()
        {
            filePath = "test.yaml";
            dataHandler.WriteToFile(Projects, filePath);

            var DataOfRead = dataHandler.ReadData(filePath);

            Assert.That(DataOfRead.Count, Is.EqualTo(Projects.Count));

            for (int i = 0; i < DataOfRead.Count; i++)
            {
                Assert.That(DataOfRead[i].Name, Is.EqualTo(Projects[i].Name));
                Assert.That(DataOfRead[i].Leader, Is.EqualTo(Projects[i].Leader));
                Assert.That(DataOfRead[i].Status, Is.EqualTo(Projects[i].Status));
                Assert.That(DataOfRead[i].Priority, Is.EqualTo(Projects[i].Priority));
            }

        }

        //====================CSV================
        [Test]
        public void WriteAndReadOfCsv()
        {
            filePath = "test.csv";
            dataHandler.WriteToFile(Projects, filePath);

            var DataOfRead = dataHandler.ReadData(filePath);

            Assert.That(DataOfRead.Count, Is.EqualTo(Projects.Count));

            for (int i = 0; i < DataOfRead.Count; i++)
            {
                Assert.That(DataOfRead[i].Name, Is.EqualTo(Projects[i].Name));
                Assert.That(DataOfRead[i].Leader, Is.EqualTo(Projects[i].Leader));
                Assert.That(DataOfRead[i].Status, Is.EqualTo(Projects[i].Status));
                Assert.That(DataOfRead[i].Priority, Is.EqualTo(Projects[i].Priority));
            }

        }


    }
    
}

