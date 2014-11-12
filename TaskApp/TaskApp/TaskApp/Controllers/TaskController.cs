using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.DAL;
using TaskApp.Models;
using TaskApp.Models.Entities;

namespace TaskApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IGenericRepository<Task> _taskRep;
        private readonly IGenericRepository<Performer> _perfRep;
        private const int PAGE_SIZE = 5;

        public TaskController(IGenericRepository<Task> taskRepository, IGenericRepository<Performer> perfRepository)
        {
            _taskRep = taskRepository;
            _perfRep = perfRepository;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            var tasks = _taskRep.Get()
                .OrderBy(task => task.Name)
                .ToList();

            var viewModel = new PaginatedListViewModel<Task>(tasks, PAGE_SIZE, pageNumber);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Performers = PerformersToSelectList();

            return View(new Task());
        }

        [HttpPost]
        public ActionResult Create(Task model)
        {
            if(ModelState.IsValid)
            {
                _taskRep.Insert(model);
                _taskRep.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Performers = PerformersToSelectList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var taskToEdit = _taskRep.Get()
                .Where(task => task.TaskId == id)
                .First();

            ViewBag.Performers = PerformersToSelectList(taskToEdit.Performer);

            return View(taskToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if(ModelState.IsValid)
            {
                _taskRep.Update(task);
                _taskRep.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Performers = PerformersToSelectList(task.Performer);
            return View(task);
        }

        public ActionResult Delete(Guid id)
        {
            var taskToDelete = _taskRep.Get()
                .Where(task => task.TaskId == id)
                .First();

            _taskRep.Delete(taskToDelete);
            _taskRep.Save();

            ViewBag.Message = string.Format("Задание {0} успешно удалено", taskToDelete.Name);

            return RedirectToAction("Index");
        }

        public ActionResult Show(Guid id)
        {
            var taskToShow = _taskRep.Get()
                .Where(task => task.TaskId == id)
                .First();

            return View(taskToShow);
        }

        private IEnumerable<SelectListItem> PerformersToSelectList(Performer performer = null)
        {
            return _perfRep.Get().ToList().Select(perf =>
            {
                return new SelectListItem()
                {
                    Text = string.Format("{0} {1} {2}", perf.Surname, perf.Name, perf.Patronymic),
                    Value = perf.PerformerId.ToString(),
                    Selected = performer == null ? false : (performer.PerformerId == perf.PerformerId)
                };
            });
        }
	}
}