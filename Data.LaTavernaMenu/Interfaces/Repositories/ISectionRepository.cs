using Data.LaTavernaMenu.DTOs;
using Data.LaTavernaMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LaTavernaMenu.Interfaces.Repositories
{
    public interface ISectionRepository
    {
        public Task<List<DataSection>> GetSections();
        public Task<DataSection> GetSectionById(Guid id);
        public void DeleteSectionById(Guid id);
        public void UpdateSectionById(Guid id, SectionDto sectionDto);
        public void Create(string title);
        public void AddDishToSectionBySectionId(Guid sectionId, SectionDto dish);

    }
}
