using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Data.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DataContext dc;
        public PropertyTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypes()
        {
            return await dc.PropertyTypes.ToListAsync();
        }
    }
}
