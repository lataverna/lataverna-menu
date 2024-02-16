using Core.LaTavernaMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Interfaces.Repositories
{
    public interface IDishRepository
    {
        public Task<Dish> GetDishByIdAsync(Guid id);
        public Task<Dish> UpdateDishAsync(Guid id, string dishName, string description, string price, bool isNew, bool isPorzione);
        public Task DeleteDishByIdAsync(Guid id);
    }
}
