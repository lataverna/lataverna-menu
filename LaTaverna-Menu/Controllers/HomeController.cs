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

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [Route("/Update/Dish")]
        public async Task<OkResult> UpdateDish([FromBody] UpdatedDishDto dish)
        {
            Guid guid = Guid.Parse(dish.Id);
            var datas = await dishRepository.UpdateDishAsync(guid, dish.DishName, dish.Description, dish.Price);
            return Ok();
        }

        [HttpGet]
        [Route("/Update/GoBack")]
        public async Task<Dish> UpdateGoBack([FromQuery] Guid id)
        {
            Dish dish = await dishRepository.GetDishByIdAsync(id);
            return dish;
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
