using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;

namespace Infraestructure.Repositories
{
    public class FornecedorRespositories : IFornecedor
    {
        private readonly MicroContext _microContext;

        public FornecedorRespositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<Fornecedores> CreateFornecedorAsync(Fornecedores fornecedor)
        {
            try
            {
                _microContext.Fornecedores.Add(fornecedor);
                await _microContext.SaveChangesAsync();
                return fornecedor;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteFornecedorAsync(int id)
        {
            try
            {
                var fornecedor = await _microContext.Fornecedores.FindAsync(id);
                if (fornecedor != null)
                {
                    _microContext.Fornecedores.Remove(fornecedor);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync()
        {
            try
            {
                return await _microContext.Fornecedores.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Fornecedores> GetFornecedorByIdAsync(int id)
        {
            try
            {
                return await _microContext.Fornecedores.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Fornecedores> GetFornecedorByNameAsync(string nome)
        {
            try
            {
                return await _microContext.Fornecedores.FirstOrDefaultAsync(f => f.Nome == nome);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Fornecedores> UpdateFornecedorAsync(Fornecedores fornecedor)
        {
            try
            {
                _microContext.Entry(fornecedor).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return fornecedor;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
