using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Models.Entities;

namespace TaskApp.DAL
{
    public class PerformerRepository : GenericRepository<Performer>
    {
        public PerformerRepository(TaskAppDBContext context)
            : base(context)
        { }
    }
}