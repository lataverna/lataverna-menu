using Core.LaTavernaMenu.DTOs;
using Core.LaTavernaMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Interfaces.Services
{
    public interface ISectionService
    {
        public Task<List<Section>> GetSections();
        public Task<Section> GetSectionById(Guid id);
        public void DeleteSectionById(Guid id);
        public void Create(string title);
        public Task AddDishToSectionBySectionId(CreateDishDto dish);
        public Task<Section> UpdateAsync(Guid id, string name);
    }
}
