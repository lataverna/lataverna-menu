using AutoMapper;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Models;
using Data.LaTavernaMenu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LaTavernaMenu.Repositories
{
    class DishRepositoryImpl : IDishRepository
    {

        private readonly AppDBContext dbContext;
        private readonly IMapper mapper;

        public DishRepositoryImpl(AppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Dish> GetDishByIdAsync(Guid id)
        {
            var dish = await dbContext.Dishes.Include(t => t.Section).FirstAsync(t => t.Id == id);
            return mapper.Map<Dish>(dish);

        }

        public async Task<Dish> UpdateDishAsync(Guid id, string dishName, string description, string price)
        {
            var dish = await dbContext.Dishes.Include(t => t.Section).FirstOrDefaultAsync(t => t.Id == id);

            dish.Description = description;
            dish.Price = price;
            dish.Name = dishName;

            dbContext.Update(dish);
            await dbContext.SaveChangesAsync();

            return mapper.Map<Dish>(dish);
        }
    }
}
