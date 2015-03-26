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
        public int VintageYear { get; set; }
        [Required]
        public int Rating { get; set; }

        // Wine Maturity Foreign Key
        public int VintageMaturityId { get; set; }
        // Wine Maturity Navigation Property
        public VintageMaturity VintageMaturity { get; set; }

        // Wine Foreign Key
        public int WineId { get; set; }
        // Wine Navigation Property
        public Wine Wine { get; set; }

        // Wine List Foreign Key
        public int WineListId { get; set; }
        // Wine List Navigation Property
        public WineList WineList { get; set; }
    }
}
