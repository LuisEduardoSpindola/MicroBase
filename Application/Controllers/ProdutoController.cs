using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProduto _produtoRepository;

        public ProdutoController(IProduto produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.GetAllProductsAsync();
            return View(produtos);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.CreateProductAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoRepository.GetProductByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoRepository.UpdateProductAsync(produto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.GetProductByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoRepository.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
