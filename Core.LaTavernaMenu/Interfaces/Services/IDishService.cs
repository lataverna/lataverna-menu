using Core.LaTavernaMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Interfaces.Services
{
    public interface IDishService
    {
        public Task<Dish> UpdateAsync(Guid guid, string dishName, string description, string price, bool isNew, bool isPorzione);

        public Task<Dish> GetDishByIdAsync(Guid guid);

        public Task DeleteAsync(Guid guid);
    }
}
