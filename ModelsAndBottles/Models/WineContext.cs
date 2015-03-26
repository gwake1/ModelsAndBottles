using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelsAndBottles.Models
{
    public class WineContext: DbContext
    {
        public DbSet<WineList> WineLists { get; set; }
        public DbSet<Terroir> Terroirs { get; set; }
        public DbSet<WineVintage> WineVintages { get; set; }
        public DbSet<Wine> Wines { get; set; } 
    }
}