using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskApp.Models.Entities;

namespace TaskApp.DAL
{
    public class DatabaseInitializer 
        : DropCreateDatabaseIfModelChanges<TaskAppDBContext>
    {
        protected override void Seed(TaskAppDBContext context)
        {
            for(var i = 0; i < 10; i++)
            {
                context.Performers.Add(new Performer()
                {
                    Name = string.Format("Имя{0}", i),
                    Surname = string.Format("Фамилия{0}", i),
                    Patronymic = string.Format("Отчество{0}", i),
                });
            }

            context.SaveChanges();
        }
    }
}