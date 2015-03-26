using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelsAndBottles.Models;

namespace ModelsAndBottles.Repository
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetWines();
    }
}