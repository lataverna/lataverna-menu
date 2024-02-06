using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Models
{
    public class Section
    {
        public Guid Id { get; set; }

        public string NameId { get; set; }

        public HashSet<Dish> Dishes { get; set;}
    }
}
