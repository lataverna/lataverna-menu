using Core.LaTavernaMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaTaverna_Menu.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public List<Section> Sections { get; set; }

        public void OnGet()
        {
            Sections = new List<Section>()
            {
                new Section()
                {
                    NameId = "PRIMI",
                    Dishes = new HashSet<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Pasta e fagioli",
                            Description = "pasta, fagioli, olio, sale, pepe",
                            Price = 12.00
                        }
                    },
                }
            };
        }
    }
}