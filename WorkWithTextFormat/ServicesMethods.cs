using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTextFormat
{
    public static class ServicesMethods
    {
        public static List<DevProject> Sort(List<DevProject> Projects, string ParameterName)
        {
            Console.WriteLine("---Sorting data---");

            List<DevProject> SortedProj = new List<DevProject>();
            if (ParameterName == "Name")
            {
                SortedProj = Projects.OrderBy(x => x.Name).ToList();
            }
            if (ParameterName == "Leader")
            {
                SortedProj = Projects.OrderBy(x => x.Leader).ToList();
            }

            if (ParameterName == "Status")
            {
                SortedProj = Projects.OrderBy(x => x.Status).ToList();
            }

            if (ParameterName == "Priority")
            {
                SortedProj = Projects.OrderBy(x => x.Priority).ToList();
            }
            else
            {
                Console.WriteLine("This parameter doesn't exist");
            }

            foreach (DevProject devProject in SortedProj)
            {
                Console.WriteLine(devProject.ToString());
            }

            return SortedProj;

        }

        public static List<DevProject> Search(string subString, List<DevProject> devProjects)
        {
            
            List<DevProject> subProjects = new List<DevProject>();

            foreach (var item in devProjects)
            {
                if (item.Name.Contains(subString) || item.Leader.Contains(subString))
                {
                    subProjects.Add(item);
                }
            }

            if (subProjects.Count == 0)
            {
                Console.WriteLine("Projects with this substruct does not exist");
            }
            else
            {
                foreach (DevProject devProject in subProjects)
                {
                    Console.WriteLine(devProject.ToString());
                }
            }

            return subProjects;
        }

      
        public static void AddDevProject(Projects projects, DevProject proj)
        {
            projects.DevProjects.Add(proj);
        }

        public static void UpdateDevProject(int devProjectID, Projects projects,
            string newName, string newLead, Status newStatus, int newPriority)
        {
            List<DevProject> Projects = projects.DevProjects.Where(x => x.Id == devProjectID).ToList();
            if (Projects.Count == 0)
            {
                throw new Exception("No project found with id - " + devProjectID);
            }
            else
            {

                Projects[0].Name = newName;
               
                Projects[0].Leader = newLead;
               
                Projects[0].Status = newStatus;
           
                Projects[0].Priority = newPriority;
            }
        }

        public static void RemoveDevProject(int devProjectID, Projects projects)
        {
            projects.DevProjects.Remove(projects.DevProjects.Where(x => x.Id == devProjectID).FirstOrDefault());
            Console.WriteLine("Remove successfull");
        }

    }
}
