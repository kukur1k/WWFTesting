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
            AddDevProject();
            break;
        case 2:
            Console.WriteLine("Enter project ID");
            projId = Convert.ToInt32(Console.ReadLine());
            RemoveDevProject(projId);
            break;
        case 3:
            Console.WriteLine("Enter project ID");
            projId = Convert.ToInt32(Console.ReadLine());
            UpdateDevProject(projId);
            break;
        case 4:
            Search(projects.DevProjects);
            break;
        case 5:
            Console.WriteLine("-----Enter parameter-----");
            Console.WriteLine("1 -- Name  2 -- Leader  3 -- Status  4 -- Priority");
            EnterParemeter = Convert.ToInt32(Console.ReadLine());
            switch (EnterParemeter)
            {
                case 1:
                    Sort(projects.DevProjects, "Name");
                    break;
                case 2:
                    Sort(projects.DevProjects, "Leader");
                    break;
                case 3:
                    Sort(projects.DevProjects, "Status");
                    break;
                case 4:
                    Sort(projects.DevProjects, "Priority");
                    break;
                default:
                    Console.WriteLine("Invalid parameter");
                    break;
            }

            break;
    }
    
}

void Sort(List<DevProject> Projects, string ParameterName)
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
    
}

void Search(List<DevProject> devProjects)
{
    Console.WriteLine("---Enter SubSting---");
    string subSting = Console.ReadLine();
    List<DevProject> subProjects = new List<DevProject>();

    foreach (var item in devProjects)
    {
        if (item.Name.Contains(subSting) || item.Leader.Contains(subSting))
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
}

void AddDevProject()
{
    DevProject devProject = new DevProject();
    Console.WriteLine("Name -- ");
    devProject.Name = Console.ReadLine();
    Console.WriteLine("Leader -- ");
    devProject.Leader = Console.ReadLine();
    Console.WriteLine("Status -- ");
    devProject.Status =  Enum.Parse<Status>(Console.ReadLine());
    Console.WriteLine("Priority -- ");
    devProject.Priority = Convert.ToInt32(Console.ReadLine());
    
    projects.DevProjects.Add(devProject);
}

void UpdateDevProject(int devProjectID)
{
    List<DevProject> Projects = projects.DevProjects.Where(x => x.Id == devProjectID).ToList();
    if (Projects.Count == 0)
    {
        throw new Exception("No project found with id - " + devProjectID);
    }
    else
    {
        Console.WriteLine("Name -- ");
        Projects[0].Name = Console.ReadLine();
        Console.WriteLine("Leader -- ");
        Projects[0].Leader = Console.ReadLine();
        Console.WriteLine("Status -- ");
        Projects[0].Status =  Enum.Parse<Status>(Console.ReadLine());
        Console.WriteLine("Priority -- ");
        Projects[0].Priority = Convert.ToInt32(Console.ReadLine());
    }
}

void RemoveDevProject(int devProjectID)
{
    projects.DevProjects.Remove(projects.DevProjects.Where(x => x.Id == devProjectID).FirstOrDefault());
    Console.WriteLine("Remove successfull");
}
