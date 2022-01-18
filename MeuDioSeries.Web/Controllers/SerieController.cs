using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuDioSeries.Web.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService<SerieViewModel> _serieService;

        public SerieController(ISerieService<SerieViewModel> serieService)
        {
            _serieService = serieService;
        }

        // GET: SerieController
        [HttpGet]
        public ActionResult Index()
        {
            return View(_serieService.GetAll());
        }

        // GET: SerieController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            return View(serieViewModel);
        }

        // GET: SerieController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                _serieService.Add(serieViewModel);
                return RedirectToAction("Index");
            }

            return View(serieViewModel);
        }

        // GET: SerieController/Edit/5
        public ActionResult Edit(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            return View(serieViewModel);
        }

        // POST: SerieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                _serieService.Update(serieViewModel);
                return RedirectToAction("Index");
            }

            return View(serieViewModel);
        }

        // GET: SerieController/Delete/5
        public ActionResult Delete(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            return View(serieViewModel);
        }

        // POST: SerieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            _serieService.Remove(serieViewModel);

            return RedirectToAction("Index");
        }
    }
}
