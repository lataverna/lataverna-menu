using AutoMapper;
using Core.LaTavernaMenu.DTOs;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Interfaces.Services;
using Core.LaTavernaMenu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;

namespace LaTaverna_Menu.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly ISectionService sectionService;
        private readonly IDishService dishService;
        private readonly IMapper mapper;

        public HomeController(ISectionService sectionService, IDishService dishService, IMapper mapper)
        {
            this.sectionService = sectionService;
            this.dishService = dishService;
            this.mapper = mapper;
        }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [Route("/Dish/Create")]
        public async Task<OkResult> Create([FromBody] CreateDishDto newDish)
        {
            await sectionService.AddDishToSectionBySectionId(newDish);
            return Ok();
        }

        [HttpPost]
        [Route("/Dish/Update")]
        public async Task<OkResult> UpdateDish([FromBody] UpdatedDishDto dish)
        {
            await dishService.UpdateAsync(dish.id, dish.dishName, dish.description, dish.price, dish.isNew, dish.weight);
            return Ok();
        }

        [HttpGet]
        [Route("/Dish/ById")]
        public async Task<Dish> UpdateGoBack([FromQuery] Guid id)
        {
            Dish dish = await dishService.GetDishByIdAsync(id);
            return dish;
        }

        [HttpDelete]
        [Route("/Dish/Delete")]
        public async Task<dynamic> Delete([FromQuery] Guid id)
        {
            await dishService.DeleteAsync(id);
            return new { Id = id };
        }

    }
}

