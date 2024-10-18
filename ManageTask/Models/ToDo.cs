using System;
using System.Collections.Generic;

namespace ToDoListProject.Models;

public partial class ToDo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StatusId { get; set; }
    //public int MemberId { get; set; }

    public string? Description { get; set; }

    public DateTime Deadline { get; set; }

    public virtual Status Status { get; set; } = null!;
    //public virtual Member Member { get; set; }

    public ToDo(string name, int statusId, string? description, DateTime deadline)
    {
        Name = name;
        StatusId = statusId;
        Description = description;
        Deadline = deadline;
    }

    public ToDo(int id, string name, int statusId, string? description, DateTime deadline)
    {
        Id = id;
        Name = name;
        StatusId = statusId;
        Description = description;
        Deadline = deadline;
    }

    public ToDo()
    {
    }

}
