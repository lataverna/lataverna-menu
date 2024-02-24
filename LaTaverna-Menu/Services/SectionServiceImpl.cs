using Core.LaTavernaMenu.DTOs;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Interfaces.Services;
using Core.LaTavernaMenu.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

namespace LaTaverna_Menu.Services
{
    public class SectionServiceImpl : ISectionService
    {
        private readonly ISectionRepository repository;

        public SectionServiceImpl(ISectionRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddDishToSectionBySectionId(CreateDishDto dish)
        {
            await repository.AddDishToSectionBySectionId(dish);
        }

        public void Create(string title)
        {
            repository.Create(title);
        }

        public void DeleteSectionById(Guid id)
        {
           repository.DeleteSectionById(id);
        }

        public Task<Section> GetSectionById(Guid id)
        {
           var section = repository.GetSectionById(id);
           return section;
        }

        public Task<List<Section>> GetSections()
        {
            var sections = repository.GetSections();
            return sections;
        }

        public async Task<Section> UpdateAsync(Guid id, string name)
        {
            var sectionUpdated = await repository.UpdateAsync(id, name);
            return sectionUpdated;
        }

    }
}
