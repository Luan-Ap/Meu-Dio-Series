using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuDioSeries.Web.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;

        public SerieController(ISerieService serieService)
        {
            _serieService = serieService;
        }

        // GET: SerieController
        [HttpGet]
        public ActionResult Index()
        {
            var series = _serieService.GetAll();

            return View(series.Result);
        }

        // GET: SerieController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            return View(serieViewModel.Result);
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
        public async Task<ActionResult> Create(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serieService.Add(serieViewModel);
                return RedirectToAction("Index");
            }

            return View(serieViewModel);
        }

        // GET: SerieController/Edit/5
        public ActionResult Edit(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            return View(serieViewModel.Result);
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
            return View(serieViewModel.Result);
        }

        // POST: SerieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var serieViewModel = _serieService.GetById(id);
            await _serieService.Remove(serieViewModel.Result);

            return RedirectToAction("Index");
        }
    }
}
