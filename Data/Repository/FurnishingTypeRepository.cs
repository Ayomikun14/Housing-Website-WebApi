using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Data.Repository
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        private readonly DataContext dc;

        public FurnishingTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypes()
        {
            return await dc.FurnishingTypes.ToListAsync();
        }
    }
}
