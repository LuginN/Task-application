using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TaskApp.Models.Entities
{
    public class Performer
    {
        public Performer()
        {
            PerformerId = Guid.NewGuid();
        }

        public Guid PerformerId { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage="Имя не может быть пустой строкой")]
        public String Name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage="Фамилия не может быть пустой строкой")]
        public String Surname { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage="Отчество не может быть пустой строкой")]
        public String Patronymic { get; set; }
    }
}