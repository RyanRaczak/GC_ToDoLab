using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GC_ToDoLab.Models
{
    public class ToDo
    {
        [Key]
        public int Todo_Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Task_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Task_Description { get; set; }

        [Required]
        [Range(1,40)]
        public int Hours_Needed { get; set; }

        public bool Is_Completed { get; set; }

        public int Assigned_To { get; set; }

        //Needed to setup relationship for Foreign Key
        public List<Employee> Employee { get; set; }

    }
}
