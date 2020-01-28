using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlinePlanner.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required]
        public string Class_Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Due_Date { get; set; }
        public string Task_Name { get; set; }

    }
}
