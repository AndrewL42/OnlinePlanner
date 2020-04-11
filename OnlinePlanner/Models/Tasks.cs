using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlinePlanner.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required]
        public string Class_Name { get; set; }

        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Due_Date { get; set; }
        public string Task_Name { get; set; }

    }
}
