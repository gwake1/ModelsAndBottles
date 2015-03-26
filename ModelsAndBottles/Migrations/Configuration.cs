using ModelsAndBottles.Models;

namespace ModelsAndBottles.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelsAndBottles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ModelsAndBottles.Models.ApplicationDbContext context)
        {
            context.WineLists.AddOrUpdate(w => w.Id,
              new WineList() { Id = 1, Name = "Delord" },
              new WineList() { Id = 2, Name = "Armagnac Castarede" },
              new WineList() { Id = 3, Name = "Chateau de Pelehaut Reserve de Gaston" },
              new WineList() { Id = 4, Name = "Hors d'Age Duperyon 15-year-old" },
              new WineList() { Id = 5, Name = "Clos Martin VSOP 8-year-old" },
              new WineList() { Id = 6, Name = "Comte de Lauvia VSOP 8-year-old" },
              new WineList() { Id = 7, Name = "Janneau 8-year-old" },
              new WineList() { Id = 8, Name = "Chateau du Tariquet Bas-Armagnac Vieux Xo" },
              new WineList() { Id = 9, Name = "Bas-Armagnac Francis Darroze 20-year-old" },
              new WineList() { Id = 10, Name = "Marquis de Montesquiou VSOP 8-year-old" }
              );

            context.Terroirs.AddOrUpdate(w => w.Id,
                new Terroir() { Id = 1, Country = "France", Region = "Armagnac", Appelation = "Bas Armagnac" },
                new Terroir() { Id = 2, Country = "France", Region = "Armagnac", Appelation = "Armagnac Tenareze" },
                new Terroir() { Id = 3, Country = "France", Region = "Armagnac", Appelation = "Haut Armagnac" }
                );

            context.VintageMaturities.AddOrUpdate(w => w.Id,
               new VintageMaturity() { Id = 1, MaturityDesc = "Caution, may be too old" },
               new VintageMaturity() { Id = 2, MaturityDesc = "Early maturing and accessible" },
               new VintageMaturity() { Id = 3, MaturityDesc = "Vintage not declared" },
               new VintageMaturity() { Id = 4, MaturityDesc = "Irregular, even among the best wines" },
               new VintageMaturity() { Id = 5, MaturityDesc = "Not yet sufficently tasted to rate" },
               new VintageMaturity() { Id = 6, MaturityDesc = "Still tannic, youthful, or slow to mature" },
               new VintageMaturity() { Id = 7, MaturityDesc = "Ready to drink" }
                );

            context.WineVintages.AddOrUpdate(w => w.Id,
                new WineVintage() { Id = 1,  VintageYear= 1992, Rating = 91, WineListId = 1, VintageMaturityId = 7, WineId = 1 },
                new WineVintage() { Id = 11, VintageYear = 1993, Rating = 91, WineListId = 1, VintageMaturityId = 7, WineId = 1 },
                new WineVintage() { Id = 2, VintageYear = 1979, Rating = 100, WineListId = 2, VintageMaturityId = 7, WineId = 2 },
                new WineVintage() { Id = 3, VintageYear = 2015, Rating = 99, WineListId = 3, VintageMaturityId = 3, WineId = 3 },
                new WineVintage() { Id = 4, VintageYear = 2015, Rating = 98, WineListId = 4, VintageMaturityId = 3, WineId = 4 },
                new WineVintage() { Id = 5, VintageYear = 2015, Rating = 97, WineListId = 5, VintageMaturityId = 3, WineId = 5 },
                new WineVintage() { Id = 6, VintageYear = 2015, Rating = 96, WineListId = 6, VintageMaturityId = 3, WineId = 6 },
                new WineVintage() { Id = 7, VintageYear = 2015, Rating = 95, WineListId = 7, VintageMaturityId = 3, WineId = 7 },
                new WineVintage() { Id = 8, VintageYear = 2015, Rating = 94, WineListId = 8, VintageMaturityId = 3, WineId = 8 },
                new WineVintage() { Id = 9, VintageYear = 2015, Rating = 93, WineListId = 9, VintageMaturityId = 3, WineId = 9 },
                new WineVintage() { Id = 10, VintageYear = 2015, Rating = 92, WineListId = 10, VintageMaturityId = 3, WineId = 10 }
                );

            context.Wines.AddOrUpdate(w => w.Id,
                new Wine() { Id = 1, WineListId = 1, TerroirId = 1, WineVintageId = 1 },
                new Wine() { Id = 2, WineListId = 2, TerroirId = 1, WineVintageId = 2 },
                new Wine() { Id = 3, WineListId = 3, TerroirId = 2, WineVintageId = 3 },
                new Wine() { Id = 4, WineListId = 4, TerroirId = 1, WineVintageId = 4 },
                new Wine() { Id = 5, WineListId = 5, TerroirId = 1, WineVintageId = 5 },
                new Wine() { Id = 6, WineListId = 6, TerroirId = 1, WineVintageId = 6 },
                new Wine() { Id = 7, WineListId = 7, TerroirId = 1, WineVintageId = 7 },
                new Wine() { Id = 8, WineListId = 8, TerroirId = 1, WineVintageId = 8 },
                new Wine() { Id = 9, WineListId = 9, TerroirId = 1, WineVintageId = 9 },
                new Wine() { Id = 10, WineListId = 10, TerroirId = 1, WineVintageId = 10 }
                );
        }
    }
}
