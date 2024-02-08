using AutoMapper;
using Core.LaTavernaMenu.Models;
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

        public async Task AddDishToSectionBySectionId(string sectionName, SectionDto dish)
        {

            DataSection section;
            section = dbContext.Sections.First(x => x.Name == sectionName);
            if (section != null && section.Dishes != null)
            {
                var newDish = new DataDish()
                {
                    Id = Guid.NewGuid(),
                    Description = dish.Description,
                    Name = dish.Name,
                    Price = dish.Price,
                    SectionId = section.Id,
                };
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
            }
            else if (section != null)
            {
                section.Dishes = new HashSet<DataDish>();

                var newDish = new DataDish()
                {
                    Id = Guid.NewGuid(),
                    Description = dish.Description,
                    Name = dish.Name,
                    Price = dish.Price,

                    SectionId = section.Id,
                };
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();

            }
        }

        public void Create(string title)
        {
            DataSection section = new DataSection()
            {
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
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<Section> GetSectionById(Guid id)
        {
            var section = await dbContext.Sections.FindAsync(id);
            if (section != null)
            {
                var obj = mapper.Map<Section>(section)!;
                return obj;
            }

            return null;

        }

        public async Task<List<Section>> GetSections()
        {
            var datas = dbContext.Sections.Include(x => x.Dishes).ToList();
            var mappedData = mapper.Map<List<Section>>(datas);
            return mappedData;
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