using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskApp.Models.Entities;

namespace TaskApp.DAL
{
    public class TaskAppDBContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Performer> Performers { get; set; }
    }
}