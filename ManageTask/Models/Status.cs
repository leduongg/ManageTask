using System;
using System.Collections.Generic;

namespace ToDoListProject.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
}
