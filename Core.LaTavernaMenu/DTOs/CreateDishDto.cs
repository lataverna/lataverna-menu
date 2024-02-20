using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.DTOs
{
    public class CreateDishDto
    {
        public Guid sectionId {  get; set; }
        public string dishName {  get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public bool newDish { get; set; }
        public bool weightDish { get; set; }

    }
}
