using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class SaidaEstoqueController : Controller
    {
        private readonly ISaidaEstoque _saidaEstoqueRepository;

        public SaidaEstoqueController(ISaidaEstoque saidaEstoqueRepository)
        {
            _saidaEstoqueRepository = saidaEstoqueRepository;
        }

        // GET: SaidaEstoque
        public async Task<IActionResult> Index()
        {
            var saidasEstoque = await _saidaEstoqueRepository.GetAllSaidasEstoqueAsync();
            return View(saidasEstoque);
        }

        // GET: SaidaEstoque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaidaEstoque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaidaEstoque saidaEstoque)
        {
            if (ModelState.IsValid)
            {
                await _saidaEstoqueRepository.CreateSaidaEstoqueAsync(saidaEstoque);
                return RedirectToAction(nameof(Index));
            }
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var saidaEstoque = await _saidaEstoqueRepository.GetSaidaEstoqueByIdAsync(id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }
            return View(saidaEstoque);
        }

        // POST: SaidaEstoque/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaidaEstoque saidaEstoque)
        {
            if (id != saidaEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _saidaEstoqueRepository.UpdateSaidaEstoqueAsync(saidaEstoque);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var saidaEstoque = await _saidaEstoqueRepository.GetSaidaEstoqueByIdAsync(id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }
            return View(saidaEstoque);
        }

        // POST: SaidaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _saidaEstoqueRepository.DeleteSaidaEstoqueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
