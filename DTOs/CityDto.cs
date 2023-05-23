using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.DTOs
{
    public class CityDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numbers are not allowed")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numbers are not allowed")]
        public string Country { get; set; }
    }
}
