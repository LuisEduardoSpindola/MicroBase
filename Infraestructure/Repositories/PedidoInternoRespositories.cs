using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class PedidoInternoRepositories : IPedidoInterno
    {
        private readonly MicroContext _microContext;

        public PedidoInternoRepositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<PedidoInterno> CreatePedidoInternoAsync(PedidoInterno pedidoInterno)
        {
            try
            {
                _microContext.PedidosInternos.Add(pedidoInterno);
                await _microContext.SaveChangesAsync();
                return pedidoInterno;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeletePedidoInternoAsync(int id)
        {
            try
            {
                var pedidoInterno = await _microContext.PedidosInternos.FindAsync(id);
                if (pedidoInterno != null)
                {
                    _microContext.PedidosInternos.Remove(pedidoInterno);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<PedidoInterno>> GetAllPedidosInternosAsync()
        {
            try
            {
                return await _microContext.PedidosInternos.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<PedidoInterno> GetPedidoInternoByIdAsync(int id)
        {
            try
            {
                return await _microContext.PedidosInternos.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<PedidoInterno> UpdatePedidoInternoAsync(PedidoInterno pedidoInterno)
        {
            try
            {
                _microContext.Entry(pedidoInterno).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return pedidoInterno;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
