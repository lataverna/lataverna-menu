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

        public async Task DeleteDishByIdAsync(Guid id)
        {
            var entity = await dbContext.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            var dish = mapper.Map<DataDish>(entity);
            dbContext.Dishes.Remove(dish);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Dish> GetDishByIdAsync(Guid id)
        {
            var dish = await dbContext.Dishes.Include(t => t.Section).FirstOrDefaultAsync(t => t.Id == id);
            var result = mapper.Map<Dish>(dish);
            return result;

        }

        public async Task<Dish> UpdateDishAsync(Guid id, string dishName, string description, string price, bool isNew, bool isPorzione)
        {
            var dish = await dbContext.Dishes.Include(t => t.Section).FirstOrDefaultAsync(t => t.Id == id);

            dish.Description = description;
            dish.Price = price;
            dish.Name = dishName;
            dish.IsNew = isNew;
            dish.IsAPorzione = isPorzione;

            dbContext.Update(dish);
            await dbContext.SaveChangesAsync();

            return mapper.Map<Dish>(dish);
        }
    }
}
