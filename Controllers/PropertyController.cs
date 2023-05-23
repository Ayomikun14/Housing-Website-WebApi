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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.photoService = photoService;
        }
        // GET: api/<PropertyController>
        [AllowAnonymous]
        [HttpGet("list/{sellRent}")]
        public async Task<IActionResult >GetProperties(int sellRent)
        {
            var properties = await uow.PropertyRepository.GetPropertiesAsync(sellRent);
            var propertiesDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertiesDto);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetPropertyDetails(int id)
        {
            var property = await uow.PropertyRepository.GetPropertyDetailsAsync(id);
            if (property == null)
            {
                return BadRequest("No property found");
            }
            var propertyDto = mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDto);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property = mapper.Map<Property>(propertyDto);
            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            uow.PropertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return Ok();
        }

        [HttpPost("add/Photo/{propId}")]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if(result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var property = await uow.PropertyRepository.GetPropertyByIdAsync(propId);
            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if(property.Photo.Count == 0)
            {
                photo.IsPrimary = true;
            }
            property.Photo.Add(photo);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        //property/set-primary-photo/1/{publicId}
        [Authorize]
        [HttpPost("set-primary-photo/{propId}/{photoPublicId}")]
        public async Task<IActionResult> SetPrimaryPhoto(int propId, string photoPublicId)
        {
            var userId = GetUserId();

            var property = await uow.PropertyRepository.GetPropertyByIdAsync(propId);

            if (property == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (property.PostedBy != userId)
            {
                return BadRequest("You are not authorised to changed the photo");
            }

            var photo = property.Photo.FirstOrDefault(p => p.PublicId == photoPublicId);

            if(photo == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (photo.IsPrimary == true)
            {
                return BadRequest("This is already a primary photo");
            }

            var currentPrimary = property.Photo.FirstOrDefault(p => p.IsPrimary);

            if (currentPrimary != null)
            {
                currentPrimary.IsPrimary = false;
            }
            photo.IsPrimary = true;

            if (await uow.SaveAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Some error has occured, failed to set primary photo");
            }
        }

        [Authorize]
        [HttpDelete("delete-photo/{propId}/{photoPublicIs}")]
        public async Task<IActionResult> DeletePhoto(int propId, string photoPublicId)
        {
            var userId = GetUserId();

            var property = await uow.PropertyRepository.GetPropertyByIdAsync(propId);

            if (property == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (property.PostedBy != userId)
            {
                return BadRequest("You are not authorised to delete this photo");
            }

            var photo = property.Photo.FirstOrDefault(p => p.PublicId == photoPublicId);
            if(photo == null)
            {
                return BadRequest("No such property or photo exists");
            }
            if (photo.IsPrimary)
            {
                return BadRequest("You can not delete primary photo");
            }

            var result = await photoService.DeletePhotoAsync(photoPublicId);
            if(result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            property.Photo.Remove(photo);

            if(await uow.SaveAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Some error has occured, failed to delete photo");
            }
        }
    }
}
