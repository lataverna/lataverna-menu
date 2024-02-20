using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.DTOs
{
    public class UpdatedDishDto
    {
        public Guid id { get; set; }
        public string dishName { get; set; } 
        public string description { get; set; } 
        public string price { get; set; }
        public bool isNew { get; set; }
        public bool weight { get; set; }
    }
}
