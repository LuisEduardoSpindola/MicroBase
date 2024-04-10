using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;

namespace Application.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServico _servicoRepository;

        public ServicoController(IServico servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        // GET: Servico
        public async Task<IActionResult> Index()
        {
            var servicos = await _servicoRepository.GetAllServicosAsync();
            return View(servicos);
        }

        // GET: Servico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servicos servico)
        {
            if (ModelState.IsValid)
            {
                await _servicoRepository.CreateServicoAsync(servico);
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }

        // GET: Servico/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var servico = await _servicoRepository.GetServicoByIdAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }

        // POST: Servico/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servicos servico)
        {
            if (id != servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _servicoRepository.UpdateServicoAsync(servico);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }

        // GET: Servico/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            var servico = await _servicoRepository.GetServicoByIdAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servicoRepository.DeleteServicoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
