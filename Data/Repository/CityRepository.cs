using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;

        public CityRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddCity(City city)
        {
            dc.Cities.AddAsync(city);
        }
        public void DeleteCity(int CityId)
        {
            var city = dc.Cities.Find(CityId);
            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await dc.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            var city = await dc.Cities.FindAsync(cityId);
            return city;
        }
    }
}
