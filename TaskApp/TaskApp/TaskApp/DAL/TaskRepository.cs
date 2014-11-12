using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Models.Entities;

namespace TaskApp.DAL
{
    public class TaskRepository : GenericRepository<Task>
    {
        public TaskRepository(TaskAppDBContext context)
            : base(context)
        { }
    }
}