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
        public async Task<ActionResult> Index()
        {
            var series = await _serieService.GetAll();

            return View(series);
        }

        // GET: SerieController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var serieViewModel = await _serieService.GetById(id);
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
        public async Task<ActionResult> Edit(int id)
        {
            var serieViewModel = await _serieService.GetById(id);
            return View(serieViewModel);
        }

        // POST: SerieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serieService.Update(serieViewModel);
                return RedirectToAction("Index");
            }

            return View(serieViewModel);
        }

        // GET: SerieController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var serieViewModel = await _serieService.GetById(id);
            return View(serieViewModel);
        }

        // POST: SerieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var serieViewModel = await _serieService.GetById(id);
            await _serieService.Remove(serieViewModel);

            return RedirectToAction("Index");
        }
    }
}
