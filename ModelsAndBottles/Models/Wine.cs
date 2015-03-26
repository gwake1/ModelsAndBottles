using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsAndBottles.Models
{
    public class Wine
    {
        [Key]
        public int Id { get; set; }

        // WineList Foreign Key
        public int WineListId { get; set; }
        // WineList Navigation property
        public virtual WineList WineList { get; set; }
        // Terroir Foreign Key

        public int TerroirId { get; set; }
        //Terroir navigation property
        public virtual Terroir Terroir { get; set; }

        // Wine Vintage Foreign Key
        public int WineVintageId { get; set; }
        // Wine Vintage Navigation Property
        public virtual ICollection<WineVintage> WineVintages { get; set; }
    }
}