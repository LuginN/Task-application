using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.DAL;
using TaskApp.Models.Entities;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    public class PerformerController : Controller
    {
        private readonly IGenericRepository<Performer> _rep;
        public const int PAGE_SIZE = 5;

        public PerformerController(IGenericRepository<Performer> rep)
        {
            _rep = rep;
        }

        public ViewResult Index(int pageNumber = 1)
        {
            var performers = _rep.Get()
                .OrderBy(m => m.Name)
                .ToList();

            var model = new PaginatedListViewModel<Performer>(performers, PAGE_SIZE, pageNumber);

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Performer());
        }

        [HttpPost]
        public ActionResult Create(Performer performer)
        {
            if(ModelState.IsValid)
            {
                _rep.Insert(performer);
                _rep.Save();
                return RedirectToAction("Index");
            }

            return View(performer);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var performerToEdit = _rep.Get()
                .Where(perf => perf.PerformerId == id)
                .First();

            return View(performerToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Performer performer)
        {
            if(ModelState.IsValid)
            {
                _rep.Update(performer);
                _rep.Save();

                return RedirectToAction("Index");
            }

            return View(performer);
        }

        public ActionResult Show(Guid id)
        {
            var performer = _rep.Get()
                .Where(perf => perf.PerformerId == id)
                .First();

            return View(performer);
        }

        public ActionResult Delete(Guid id)
        {
            var entityToDelete = _rep.Get().Where(perf => perf.PerformerId == id)
                .First();

            _rep.Delete(entityToDelete);
            _rep.Save();
            ViewBag.Message = string.Format("{0} успешно удалён.", entityToDelete.Name);

            return RedirectToAction("Index");
        }
    }
}