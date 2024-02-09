using AutoMapper;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Models;
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
        
            List<Section> list = await repository.GetSections();

            Sections = list;
        }
    }
}