using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EntradaEstoqueRepositories : IEntradaEstoque
    {
        private readonly MicroContext _microContext;

        public EntradaEstoqueRepositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<EntradaEstoque> CreateEntradaEstoqueAsync(EntradaEstoque entradaEstoque)
        {
            try
            {
                _microContext.EntradasEstoque.Add(entradaEstoque);
                await _microContext.SaveChangesAsync();
                return entradaEstoque;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteEntradaEstoqueAsync(int id)
        {
            try
            {
                var entradaEstoque = await _microContext.EntradasEstoque.FindAsync(id);
                if (entradaEstoque != null)
                {
                    _microContext.EntradasEstoque.Remove(entradaEstoque);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<EntradaEstoque>> GetAllEntradaEstoqueAsync()
        {
            try
            {
                return await _microContext.EntradasEstoque.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<EntradaEstoque>> GetAllEntradasEstoqueAsync()
        {
            try
            {
                return await _microContext.EntradasEstoque.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<EntradaEstoque> GetEntradaEstoqueByIdAsync(int id)
        {
            try
            {
                return await _microContext.EntradasEstoque.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<EntradaEstoque> UpdateEntradaEstoqueAsync(EntradaEstoque entradaEstoque)
        {
            try
            {
                _microContext.Entry(entradaEstoque).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return entradaEstoque;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
