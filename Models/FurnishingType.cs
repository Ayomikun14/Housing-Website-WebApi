using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class FurnishingType: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}