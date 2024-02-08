using AutoMapper;
using Core.LaTavernaMenu.Models;
using Data.LaTavernaMenu.DTOs;
using Data.LaTavernaMenu.Interfaces.Repositories;
using Data.LaTavernaMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaTaverna_Menu.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ISectionRepository repository;

        private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger, ISectionRepository repository, IMapper mapper)
        {
            _logger = logger;
            this.repository = repository;
            _mapper = mapper;
        }
        public List<Section> Sections { get; set; }

        public async void OnGet()
        {
            //IL CREA DEVE CONTROLLARE CHE LA STRINGA IMMESSA NON SIA GIA' PRESENTE
            //repository.Create("PRIMI");
            //repository.Create("GRIGLIA");
            
            //var sectionList = new List<Section>()
            //{
            //    new Section()
            //    {
            //        Name = "PRIMI",
            //        Dishes = new HashSet<Dish>()
            //        {
            //            new Dish()
            //            {
            //                Name = "Pasta e ceci",
            //                Description = "pasta, ceci, olio, sale, pepe",
            //                Price = "19,90 a porzione"
            //            },
            //            new Dish()
            //            {
            //                Name = "Pasta e fagioli",
            //                Description = "pasta, fagioli, olio, sale, pepe",
            //                Price = "9,90 a porzione"
            //            }
            //        },
            //    },
            //    new Section()
            //    {
            //        Name = "GRIGLIA",
            //        Dishes = new HashSet<Dish>()
            //        {
            //            new Dish()
            //            {
            //                Name = "Fiorentina",
            //                Description = "minimo 800 gr.",
            //                Price = "29,90 all'etto"
            //            },
            //        },
            //    }
            //};

            //foreach (var section in sectionList)
            //{
            //    foreach (var dish in section.Dishes)
            //    {
            //        SectionDto dto = new SectionDto()
            //        {
            //            SectionName = section.Name,
            //            Description = dish.Description,
            //            Name = dish.Name,
            //            Price = dish.Price

            //        };

            //        await repository.AddDishToSectionBySectionId(section.Name, dto);
            //    }
            //}

            List<Section> list = await repository.GetSections();

            Sections = list;
        }
    }
}