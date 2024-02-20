using AutoMapper;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Interfaces.Services;
using Core.LaTavernaMenu.Models;

namespace LaTaverna_Menu.Services
{
    public class DishServiceImpl : IDishService
    {

        private readonly IDishRepository repository;
        private readonly IMapper mapper;

        public DishServiceImpl(IDishRepository _repository, IMapper _mapper)
        {
            this.repository = _repository;
            this.mapper = _mapper;
        }

        public async Task DeleteAsync(Guid guid)
        {
            await repository.DeleteDishByIdAsync(guid);
        }

        public async Task<Dish> GetDishByIdAsync(Guid guid)
        {
            var dish = await repository.GetDishByIdAsync(guid);
            return dish;
        }

        public async Task<Dish> UpdateAsync(Guid guid, string dishName, string description, string price, bool isNew, bool isPorzione)
        {
            var dish = await repository.UpdateDishAsync(guid, dishName, description, price, isNew, isPorzione);
            return dish;
        }
    }
}
