using Core.LaTavernaMenu.DTOs;
using Core.LaTavernaMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LaTavernaMenu.Interfaces.Repositories
{
    public interface ISectionRepository
    {
        public Task<List<Section>> GetSections();
        public Task<Section> GetSectionById(Guid id);
        public void DeleteSectionById(Guid id);
        public void UpdateSectionById(Guid id, SectionDto sectionDto);
        public void Create(string title);
        public Task AddDishToSectionBySectionId(string sectionName, SectionDto dish);

    }
}
