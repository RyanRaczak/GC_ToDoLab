using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GC_ToDoLab.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [Range(0,40)]
        public int Hours { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

    }
}
