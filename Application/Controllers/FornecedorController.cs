using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedor _fornecedorRepository;

        public FornecedorController(IFornecedor fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _fornecedorRepository.GetAllFornecedoresAsync();
            return View(fornecedores);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedores fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorRepository.CreateFornecedorAsync(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fornecedores fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fornecedorRepository.UpdateFornecedorAsync(fornecedor);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fornecedorRepository.DeleteFornecedorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
