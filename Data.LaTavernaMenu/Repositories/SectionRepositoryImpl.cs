using AutoMapper;
using Data.LaTavernaMenu.DTOs;
using Data.LaTavernaMenu.Interfaces.Repositories;
using Data.LaTavernaMenu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LaTavernaMenu.Repositories
{
    class SectionRepositoryImpl : ISectionRepository
    {
        private readonly AppDBContext dbContext;
        private readonly IMapper mapper;

        public SectionRepositoryImpl(AppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async void AddDishToSectionBySectionId(Guid sectionId, SectionDto dish)
        {

            DataSection section;
            section = await dbContext.Sections.FirstAsync(x => x.Id == sectionId);
            if (section != null)
            {
                section.Dishes.Add(new DataDish()
                {
                    Description = dish.Description,
                    Name = dish.Name,
                    Price = dish.Price,
                });

                dbContext.Sections.Update(section);
            }
        }

        public void Create(string title)
        {
            DataSection section = new DataSection()
            {
                Id = Guid.NewGuid(),
                Name = title,
                Dishes = new HashSet<DataDish>()
            };

            dbContext.Sections.Add(section);
            dbContext.SaveChanges();

        }

        public async void DeleteSectionById(Guid id)
        {
            var section = await dbContext.Sections.FindAsync(id);
            if (section != null)
            {
                dbContext.Sections.Remove(section);
                dbContext.SaveChanges();
            }

        }

        public async Task<DataSection> GetSectionById(Guid id)
        {
            var section = await dbContext.Sections.FindAsync(id);
            if (section != null)
            {
                return section;
            }

            return null;

        }

        public async Task<List<DataSection>> GetSections()
        {
            var datas = await dbContext.Sections.ToListAsync();
            return datas;
        }

        public async void UpdateSectionById(Guid id, SectionDto sectionDto)
        {
            var section = await dbContext.Sections.FindAsync(id);
            var dishList = section.Dishes;
            var objDish = dishList.Where(x => x.Name == sectionDto.Name).First();
            var updatedDish = new DataDish()
            {
                //METODO PER RECUPERARE DISH CON IL NAME
                Id = objDish.Id,
                Name = sectionDto.Name,
                Description = sectionDto.Description,
                Price = sectionDto.Price,
            };

            dishList.Remove(objDish);
            dishList.Add(updatedDish);

            var updatedSection = new DataSection
            {
                Id = section.Id,
                Name = sectionDto.Name,
                Dishes = dishList,
            };

            dbContext.Sections.Update(updatedSection);
        }
    }
}