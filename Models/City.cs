using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Models
{
    public class City: BaseEntity
    {
        public string Name{ get; set; }
        public string Country { get; set; }
    }
}
