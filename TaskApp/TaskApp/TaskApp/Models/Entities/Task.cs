using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TaskApp.Models.Entities
{
    public class Task
    {
        public Guid TaskId { get; set; }

        public Task()
        {
            TaskId = Guid.NewGuid();
            Status = TaskStatus.NotStarted;
        }

        [DisplayName("Название")]
        [Required(ErrorMessage="Название задачи не может быть пустой строкой")]
        public String Name { get; set; }

        [DisplayName("Обьем работ")]
        [Range(1, Int32.MaxValue)]
        [Required(ErrorMessage="Обьем работ должен быть указан")]
        public int WorkVolume { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата начала")]
        [Required(ErrorMessage="Дата начала должна быть выбрана")]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата конца")]
        [Required(ErrorMessage = "Дата конца должна быть выбрана")]
        public DateTime EndDate { get; set; }

        [DisplayName("Статус")]
        [Required(ErrorMessage="Статус задачи должен быть определён")]
        public TaskStatus Status { get; set; }

        [DisplayName("Исполнитель")]
        [Required(ErrorMessage = "Выберите исполнителя")]
        public Guid PerformerId { get; set; }
        
        public virtual Performer Performer { get; set; }

    }
}