using System.Collections.Generic;
using System.Net.Http.Json;
using WorkWithTextFormat;


var dataHandler = new WorkwithData<DevProject>();
Projects projects = new Projects();

int ExitFlag = -1;

while (ExitFlag != 0)
{
    Console.WriteLine("--------------Enter group of Operations-------------");
    Console.WriteLine("1 ------- Work with struct    2 ------- De/Serialize");
    Console.WriteLine("                   0 ------- Exit                   ");
    int flagOperType = Convert.ToInt32(Console.ReadLine());
    ExitFlag = flagOperType;
    if (ExitFlag == 0)
    {
        Environment.Exit(0);
    }
    switch (flagOperType)
    {
        case 1:
            StructOperations();
            break;
        case 2:
            SerOperations();
            break;
        
    }
}



    void SerOperations()
    {
        Console.WriteLine("------------------Enter operation---------------");
        Console.WriteLine("  1 -- Write  2 -- Read  3 -- Print data");
        int flagOperType = Convert.ToInt32(Console.ReadLine());
        int projId = 0;
        string filePath = "";
        switch (flagOperType)
        {
            case 1:
                Console.WriteLine("--Enter File path--");
                filePath = Console.ReadLine();
                dataHandler.WriteToFile(projects.DevProjects, filePath);
                break;
            case 2:
                Console.WriteLine("--Enter File path--");
                filePath = Console.ReadLine();
                projects.DevProjects = dataHandler.ReadData(filePath);
                
                //Выбираем максимальный ID и назначаем текущим следующий
                int MaxId = projects.DevProjects.Max(x => x.Id);
                DevProject.SetCurrentID(MaxId+1);
                
                
                break;
            case 3:
                try
                {
                    foreach (DevProject devProject in projects.DevProjects)
                    {
                        Console.WriteLine(devProject.ToString());
                    }
                }
                catch { Console.WriteLine("Data does not exist"); }

                break;

        }
    }


void StructOperations()
{
    Console.WriteLine("------------------------------Enter operation---------------------------");
    Console.WriteLine("  1 --- Add Project  2 --- Remove  3 --- Update 4 --- Search  5 -- Sort ");
    int EnterParemeter = 0;
    int flagOperType = Convert.ToInt32(Console.ReadLine());
    int projId = 0;
    switch (flagOperType)
    {
        case 1:
            DevProject devProject = new DevProject();
            Console.WriteLine("Name -- ");
            devProject.Name = Console.ReadLine();
            Console.WriteLine("Leader -- ");
            devProject.Leader = Console.ReadLine();
            Console.WriteLine("Status -- ");
            devProject.Status = Enum.Parse<Status>(Console.ReadLine());
            Console.WriteLine("Priority -- ");
            devProject.Priority = Convert.ToInt32(Console.ReadLine());
            ServicesMethods.AddDevProject(projects, devProject);
            break;
        case 2:
            Console.WriteLine("Enter project ID");
            projId = Convert.ToInt32(Console.ReadLine());
            ServicesMethods.RemoveDevProject(projId, projects);
            break;
        case 3:
            Console.WriteLine("Enter project ID");
            projId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name -- ");
            string Name = Console.ReadLine();
            Console.WriteLine("Leader -- ");
            string Leader = Console.ReadLine();
            Console.WriteLine("Status -- ");
            Status Status = Enum.Parse<Status>(Console.ReadLine());
            Console.WriteLine("Priority -- ");
            int Priority = Convert.ToInt32(Console.ReadLine());
            ServicesMethods.UpdateDevProject(projId, projects, Name, Leader, Status, Priority);
            break;
        case 4:
            Console.WriteLine("---Enter SubSting---");
            string subString = Console.ReadLine();
            List<DevProject> subList = ServicesMethods.Search(subString, projects.DevProjects);
            break;
        case 5:
            Console.WriteLine("-----Enter parameter-----");
            Console.WriteLine("1 -- Name  2 -- Leader  3 -- Status  4 -- Priority");
            EnterParemeter = Convert.ToInt32(Console.ReadLine());
            switch (EnterParemeter)
            {
                case 1:
                    projects.DevProjects = ServicesMethods.Sort(projects.DevProjects, "Name");
                    break;
                case 2:
                    projects.DevProjects = ServicesMethods.Sort(projects.DevProjects, "Leader");
                    break;
                case 3:
                    projects.DevProjects = ServicesMethods.Sort(projects.DevProjects, "Status");
                    break;
                case 4:
                    projects.DevProjects = ServicesMethods.Sort(projects.DevProjects, "Priority");
                    break;
                default:
                    Console.WriteLine("Invalid parameter");
                    break;
            }

            break;
    }
    
}

