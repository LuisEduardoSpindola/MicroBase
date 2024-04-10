using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class OrdemCompraRepositores : IOrdemCompra
    {
        private readonly MicroContext _microContext;

        public OrdemCompraRepositores(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<OrdemCompra> CreateOrdemCompraAsync(OrdemCompra ordemCompra)
        {
            try
            {
                _microContext.OrdensCompra.Add(ordemCompra);
                await _microContext.SaveChangesAsync();
                return ordemCompra;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteOrdemCompraAsync(int id)
        {
            try
            {
                var ordemCompra = await _microContext.OrdensCompra.FindAsync(id);
                if (ordemCompra != null)
                {
                    _microContext.OrdensCompra.Remove(ordemCompra);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<OrdemCompra>> GetAllOrdensCompraAsync()
        {
            try
            {
                return await _microContext.OrdensCompra.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<OrdemCompra> GetOrdemCompraByIdAsync(int id)
        {
            try
            {
                return await _microContext.OrdensCompra.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<OrdemCompra> UpdateOrdemCompraAsync(OrdemCompra ordemCompra)
        {
            try
            {
                _microContext.Entry(ordemCompra).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return ordemCompra;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
