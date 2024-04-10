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
    public class ProdutoRespositories : IProduto
    {
        private readonly MicroContext _microContext;

        public ProdutoRespositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<Produto> CreateProductAsync(Produto produto)
        {
            try
            {
                _microContext.Produtos.Add(produto);
                await _microContext.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteProductAsync(int Id)
        {
            try
            {
                var produto = await _microContext.Produtos.FindAsync(Id);
                if (produto != null)
                {
                    _microContext.Produtos.Remove(produto);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<Produto>> GetAllProductsAsync()
        {
            try
            {
                return await _microContext.Produtos.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Produto> GetProductByEanAsync(int Ean)
        {
            try
            {
                return await _microContext.Produtos.FirstOrDefaultAsync(p => p.Ean == Ean);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Produto> GetProductByIdAsync(int Id)
        {
            try
            {
                return await _microContext.Produtos.FindAsync(Id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Produto> GetProductByNameAsync(string Nome)
        {
            try
            {
                return await _microContext.Produtos.FirstOrDefaultAsync(p => p.Nome == Nome);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Produto> UpdateProductAsync(Produto produto)
        {
            try
            {
                _microContext.Entry(produto).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }
}
