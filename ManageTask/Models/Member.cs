using System;
using System.Collections.Generic;

namespace ToDoListProject.Models;
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
    }

