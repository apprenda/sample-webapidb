using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.DataService.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}