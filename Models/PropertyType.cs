using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class PropertyType:BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}