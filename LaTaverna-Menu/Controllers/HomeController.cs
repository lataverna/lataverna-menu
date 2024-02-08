using Core.LaTavernaMenu.Models;
using Data.LaTavernaMenu.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaTaverna_Menu.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISectionRepository repository;

        public HomeController(ISectionRepository repository)
        {
            this.repository = repository;
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

        // GET: HomeController/Edit/5
        [Route("Update/Dish")]
        public ActionResult UpdateDish(string nomePiatto, string descrizione, string prezzo)
        {
            return View();
        }

        [Route("Update/GoBack")]
        public async Task UpdateGoBack([FromQuery] Guid id)
        {
            Section obj = await repository.GetSectionById(id);
            var result = new
            {
                id = id,
                dishName
            };
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
