using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Models;

namespace MyWebApi.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityAsync(int cityId);
        void AddCity(City city);
        void DeleteCity(int CityId);
        Task<City> FindCity(int id);
    }
}
