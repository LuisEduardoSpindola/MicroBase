using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class OrdemCompraController : Controller
    {
        private readonly IOrdemCompra _ordemCompraRepository;

        public OrdemCompraController(IOrdemCompra ordemCompraRepository)
        {
            _ordemCompraRepository = ordemCompraRepository;
        }

        // GET: OrdemCompra
        public async Task<IActionResult> Index()
        {
            var ordensCompra = await _ordemCompraRepository.GetAllOrdensCompraAsync();
            return View(ordensCompra);
        }

        // GET: OrdemCompra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdemCompra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdemCompra ordemCompra)
        {
            if (ModelState.IsValid)
            {
                await _ordemCompraRepository.CreateOrdemCompraAsync(ordemCompra);
                return RedirectToAction(nameof(Index));
            }
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var ordemCompra = await _ordemCompraRepository.GetOrdemCompraByIdAsync(id);
            if (ordemCompra == null)
            {
                return NotFound();
            }
            return View(ordemCompra);
        }

        // POST: OrdemCompra/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrdemCompra ordemCompra)
        {
            if (id != ordemCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ordemCompraRepository.UpdateOrdemCompraAsync(ordemCompra);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var ordemCompra = await _ordemCompraRepository.GetOrdemCompraByIdAsync(id);
            if (ordemCompra == null)
            {
                return NotFound();
            }
            return View(ordemCompra);
        }

        // POST: OrdemCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ordemCompraRepository.DeleteOrdemCompraAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
