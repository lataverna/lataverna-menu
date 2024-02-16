using AutoMapper;
using Core.LaTavernaMenu.DTOs;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;

namespace LaTaverna_Menu.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly ISectionRepository sectionRepository;
        private readonly IDishRepository dishRepository;
        private readonly IMapper mapper;

        public HomeController(ISectionRepository sectionRepository, IDishRepository dishRepository, IMapper mapper)
        {
            this.sectionRepository = sectionRepository;
            this.dishRepository = dishRepository;
            this.mapper = mapper;
        }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("/Dish/Update")]
        public async Task<OkResult> UpdateDish([FromBody] UpdatedDishDto dish)
        {
            var datas = await dishRepository.UpdateDishAsync(dish.Id  , dish.DishName, dish.Description, dish.Price, dish.IsNew, dish.IsPorzione);
            return Ok();
        }

        [HttpGet]
        [Route("/Dish/GoBack")]
        public async Task<Dish> UpdateGoBack([FromQuery] Guid id)
        {
            Dish dish = await dishRepository.GetDishByIdAsync(id);
            return dish;
        }

        [HttpDelete]
        [Route("/Dish/Delete")]
        public async Task<dynamic> Delete([FromQuery] Guid id)
        {
            await dishRepository.DeleteDishByIdAsync(id);
            return new { Id = id };
        }

        // POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
