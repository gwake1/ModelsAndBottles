using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelsAndBottles.Models;

namespace ModelsAndBottles.Repository
{
    public class WineRepository: IWineRepository
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public IEnumerable<Models.Wine> GetWines()
        {
            return dbContext.Wines.ToList();
        }
    }
}