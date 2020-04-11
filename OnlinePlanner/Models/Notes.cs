using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePlanner.Models
{
    public class Notes
    {
        public int Id { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        [DisplayName("Notes")]
        public string Note { get; set; }

    }
}
