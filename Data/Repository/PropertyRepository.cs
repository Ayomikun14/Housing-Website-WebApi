using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Data.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dc;

        public PropertyRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddProperty(Property property)
        {
            dc.Properties.AddAsync(property);
        }

        public void DeleteProperty(int Id)
        {
            var property = dc.Properties.Find(Id);
            dc.Properties.Remove(property);
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
        {
            var properties = await dc.Properties
                .Include(x=> x.PropertyType)
                .Include(x=> x.City)
                .Include(x=> x.FurnishingType)
                .Include(x=>x.Photo)
                .Where(x=> x.SellRent == sellRent)
                .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailsAsync(int id)
        {
            var properties = await dc.Properties
                   .Include(x => x.PropertyType)
                   .Include(x => x.City)
                   .Include(x => x.FurnishingType)
                   .Include(x => x.Photo)
                   .Where(x => x.Id == id)
                   .FirstOrDefaultAsync();
            return properties;
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var properties = await dc.Properties
                   .Include(x => x.Photo)
                   .Where(x => x.Id == id)
                   .FirstOrDefaultAsync();
            return properties;
        }
    }
}
