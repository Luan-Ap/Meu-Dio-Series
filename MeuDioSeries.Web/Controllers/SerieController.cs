using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Web.Controllers
{
    [Authorize]
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IGeneroService _generoService;

        public SerieController(ISerieService serieService, IGeneroService generoService)
        {
            _serieService = serieService;
            _generoService = generoService;
        }

        // GET: SerieController
        [HttpGet]
        public async Task<ActionResult> Index(string title = null)
        {
            ViewData["BuscarSeries"] = title;

            IEnumerable<SerieViewModel> series;

            if (!string.IsNullOrEmpty(title))
            {
                series = await _serieService.GetSeriesByTitleAsync(title);

                return View(series);
            }
            else
            {
                series = await _serieService.GetAllAsync();

                return View(series);
            }
        }

        // GET: SerieController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var serieViewModel = await _serieService.GetByIdAsync(id);
            return View(serieViewModel);
        }

        // GET: SerieController/Create
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.GeneroId = new SelectList( await _generoService.GetAllAsync(), "GeneroId", "Nome");
            return View();
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serieService.AddAsync(serieViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(await _generoService.GetAllAsync(), "GeneroId", "Nome", serieViewModel.GeneroId);
            return View(serieViewModel);
        }

        // GET: SerieController/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            var serieViewModel = await _serieService.GetByIdAsync(id);

            ViewBag.GeneroId = new SelectList(await _generoService.GetAllAsync(), "GeneroId", "Nome", serieViewModel.GeneroId);
            
            return View(serieViewModel);
        }

        // POST: SerieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SerieViewModel serieViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serieService.UpdateAsync(serieViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(await _generoService.GetAllAsync(), "GeneroId", "Nome", serieViewModel.GeneroId);
            return View(serieViewModel);
        }

        // GET: SerieController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var serieViewModel = await _serieService.GetByIdAsync(id);
            return View(serieViewModel);
        }

        // POST: SerieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var serieViewModel = await _serieService.GetByIdAsync(id);
            await _serieService.RemoveAsync(serieViewModel);

            return RedirectToAction("Index");
        }
    }
}
