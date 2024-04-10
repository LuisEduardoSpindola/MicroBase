using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class EntradaEstoqueController : Controller
    {
        private readonly IEntradaEstoque _entradaEstoqueRepository;

        public EntradaEstoqueController(IEntradaEstoque entradaEstoqueRepository)
        {
            _entradaEstoqueRepository = entradaEstoqueRepository;
        }

        // GET: EntradaEstoque
        public async Task<IActionResult> Index()
        {
            var entradasEstoque = await _entradaEstoqueRepository.GetAllEntradasEstoqueAsync();
            return View(entradasEstoque);
        }

        // GET: EntradaEstoque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntradaEstoque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntradaEstoque entradaEstoque)
        {
            if (ModelState.IsValid)
            {
                await _entradaEstoqueRepository.CreateEntradaEstoqueAsync(entradaEstoque);
                return RedirectToAction(nameof(Index));
            }
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var entradaEstoque = await _entradaEstoqueRepository.GetEntradaEstoqueByIdAsync(id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }
            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntradaEstoque entradaEstoque)
        {
            if (id != entradaEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _entradaEstoqueRepository.UpdateEntradaEstoqueAsync(entradaEstoque);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var entradaEstoque = await _entradaEstoqueRepository.GetEntradaEstoqueByIdAsync(id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }
            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _entradaEstoqueRepository.DeleteEntradaEstoqueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
