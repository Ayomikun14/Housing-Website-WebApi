using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.DTOs
{
    public class PropertyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PropertyType { get; set; }
        public string FurnishingType { get; set; }
        public int Price { get; set; }
        public int BHK { get; set; }
        public int BuiltArea { get; set; }
        public string  City { get; set; }
        public string Country { get; set; }
        public bool ReadyToMove { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public string Photo { get; set; } 

    }
}
