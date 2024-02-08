using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Models
{
    public class Section
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public HashSet<Dish> Dishes { get; set;}
    }
}
