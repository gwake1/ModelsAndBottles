using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelsAndBottles.Models
{
    public class WineVintage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int WineListId { get; set; }
        [Required]
        public string Maturity { get; set; }
        [Required]
        public int Rating { get; set; }

        // Wine Foreign Key
        public int WineId { get; set; }
        // Wine Navigation Property
        public Wine Wine { get; set; }
    }
}
