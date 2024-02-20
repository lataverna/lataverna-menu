using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Models
{
    public class Dish
    {
        [Key]
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Price")]
        public string Price { get; set; }
        [JsonPropertyName("IsNew")]
        public bool IsNew { get; set; }
        [JsonPropertyName("Weight")]
        public bool IsAPorzione { get; set; } // indica se è all'etto o a porzione
    }
}
