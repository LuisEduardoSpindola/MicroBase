using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class SaidaRepositories : ISaidaEstoque
    {
        private readonly MicroContext _microContext;

        public SaidaRepositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<SaidaEstoque> CreateSaidaEstoqueAsync(SaidaEstoque saidaEstoque)
        {
            try
            {
                _microContext.SaidasEstoque.Add(saidaEstoque);
                await _microContext.SaveChangesAsync();
                return saidaEstoque;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteSaidaEstoqueAsync(int id)
        {
            try
            {
                var saidaEstoque = await _microContext.SaidasEstoque.FindAsync(id);
                if (saidaEstoque != null)
                {
                    _microContext.SaidasEstoque.Remove(saidaEstoque);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<SaidaEstoque>> GetAllSaidasEstoqueAsync()
        {
            try
            {
                return await _microContext.SaidasEstoque.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<SaidaEstoque> GetSaidaEstoqueByIdAsync(int id)
        {
            try
            {
                return await _microContext.SaidasEstoque.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<SaidaEstoque> UpdateSaidaEstoqueAsync(SaidaEstoque saidaEstoque)
        {
            try
            {
                _microContext.Entry(saidaEstoque).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return saidaEstoque;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
