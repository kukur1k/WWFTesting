using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTextFormat;

public class Projects
{
    public List<DevProject> DevProjects { get; set; }
}

[Serializable]
public class DevProject
{

    public int Id { get; set; }

public string Name { get; set; }
    public string Leader { get; set; }
    public Status Status { get; set; }
    public int Priority { get; set; }

    //ID счетчик 
    [NonSerialized]
    private static int currentId = 1;

    public DevProject()
    {
        Id = currentId++;
    }

    public static int SetCurrentID(int devProjectID)
    {
        currentId = devProjectID;
        return currentId;
    }
    
    public DevProject(string name, string leader, Status status, int priority)
    {
        Id = currentId++;
        Name = name;
        Leader = leader;
        Status = status;
        Priority = priority;
    }

    public static void ResetID()
    {
        currentId = 1;
    }

    public override string ToString()
    {
        return $"Id -- {Id}" +
            $" | Name -- {Name}" +
            $" | Leader--{Leader}" +
            $" | Status--{Status}" +
            $" | Priority--{Priority}";
    }

}

