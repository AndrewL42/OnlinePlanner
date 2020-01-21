using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePlanner.Models
{
    public class Classes
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Class_Name { get; set; }
        public string Class_Days { get; set; }
        public string Class_Times { get; set; }
    }
}
