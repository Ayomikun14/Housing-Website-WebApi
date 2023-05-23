using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.DTOs;
using MyWebApi.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        private readonly IMapper mapper;

        public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;

            this.mapper = mapper;
        }
        // GET: api/propertytype/list
        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var propertyTypes = await uow.PropertyTypeRepository.GetPropertyTypes();
            var PropertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(propertyTypes);
            return Ok(PropertyTypesDto);
        }
    }
}
