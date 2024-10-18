using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject.Models
{
    public class ToDoAndStatuses
    {
        public ToDo ToDo { get; set; }
        public List<Status> AllStatus { get; set; }
        public Status SelectedStatus { get; set; }

        public ToDoAndStatuses(ToDo toDo, List<Status> allStatus, Status selectedStatus)
        {
            ToDo = toDo;
            AllStatus = allStatus;
            SelectedStatus = selectedStatus;
        }

        
    }
}
