using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TaskApp.Models.Entities
{
    public enum TaskStatus
    {
        [Description("Не начата")]
        NotStarted,

        [Description("В процессе")]
        InProcess,

        [Description("Выполнена")]
        Completed,

        [Description("Отложена")]
        Deffered
    }
}