using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.DTOs
{
    public class UpdatedDishDto
    {
        public string Id { get; set; } = string.Empty;
        public string DishName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
