using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.DTOs;
using MyWebApi.Models;

namespace MyWebApi.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);
        void AddProperty(Property property);
        void DeleteProperty(int Id);
        Task<Property> GetPropertyDetailsAsync(int id);
        Task<Property> GetPropertyByIdAsync(int id);
    }
}
