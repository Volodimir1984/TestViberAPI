using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestViberAPI.Models
{
    public class UserDisplay
    {
        public int Id { get; set; }
        public string IdViber { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }      
        public string DeviceType { get; set; }
    }
}
