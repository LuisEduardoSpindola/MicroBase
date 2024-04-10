using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class PedidoInternoController : Controller
    {
        private readonly IPedidoInterno _pedidoInternoRepository;

        public PedidoInternoController(IPedidoInterno pedidoInternoRepository)
        {
            _pedidoInternoRepository = pedidoInternoRepository;
        }

        // GET: PedidoInterno
        public async Task<IActionResult> Index()
        {
            var pedidosInternos = await _pedidoInternoRepository.GetAllPedidosInternosAsync();
            return View(pedidosInternos);
        }

        // GET: PedidoInterno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoInterno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoInterno pedidoInterno)
        {
            if (ModelState.IsValid)
            {
                await _pedidoInternoRepository.CreatePedidoInternoAsync(pedidoInterno);
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var pedidoInterno = await _pedidoInternoRepository.GetPedidoInternoByIdAsync(id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PedidoInterno pedidoInterno)
        {
            if (id != pedidoInterno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pedidoInternoRepository.UpdatePedidoInternoAsync(pedidoInterno);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoInterno = await _pedidoInternoRepository.GetPedidoInternoByIdAsync(id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pedidoInternoRepository.DeletePedidoInternoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
