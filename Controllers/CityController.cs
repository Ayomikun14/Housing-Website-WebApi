using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.DTOs;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET api/city
         [HttpGet]
         [AllowAnonymous]
         public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map <IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }

        // Post the data in JSON Format
        [HttpPost("addCity")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await uow.CityRepository.GetCityAsync(id);
            return Ok(city);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);        
        }

        [HttpPut("updateCity/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            if(id != cityDto.Id)
            {
                return BadRequest("Update not allowed");
            }
            var city = await uow.CityRepository.FindCity(id);
            if (city == null)
            {
                return BadRequest("Update not allowed");
            }
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, city);
            await uow.SaveAsync();
            return Ok();
        }
    }
}
