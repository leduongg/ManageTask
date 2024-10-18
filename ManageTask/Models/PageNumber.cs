using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject.Models
{
    public class PageNumber
    {
        public int pageNumber { get; set; }

        public PageNumber(int pageNumber)
        {
            this.pageNumber = pageNumber;
        }
    }
}
