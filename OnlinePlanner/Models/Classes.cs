using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePlanner.Models
{
    public class Classes
    {

        public int Id { get; set; }

        public string Username { get; set; }

        [Required]
        [DisplayName("Class Name")]
        public string Class_Name { get; set; }

        [Required]
        [DisplayName("Class Days")]
        public string Class_Days { get; set; }

        [DisplayName("Class Times")]
        public string Class_Times { get; set; }

    }
}
