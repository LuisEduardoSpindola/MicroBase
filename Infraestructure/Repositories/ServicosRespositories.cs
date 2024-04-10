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
    public class ServicoRepositories : IServico
    {
        private readonly MicroContext _microContext;

        public ServicoRepositories(MicroContext microContext)
        {
            _microContext = microContext;
        }

        public async Task<Servicos> CreateServicoAsync(Servicos servico)
        {
            try
            {
                _microContext.Servicos.Add(servico);
                await _microContext.SaveChangesAsync();
                return servico;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task DeleteServicoAsync(int id)
        {
            try
            {
                var servico = await _microContext.Servicos.FindAsync(id);
                if (servico != null)
                {
                    _microContext.Servicos.Remove(servico);
                    await _microContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<Servicos>> GetAllServicosAsync()
        {
            try
            {
                return await _microContext.Servicos.ToListAsync();
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Servicos> GetServicoByIdAsync(int id)
        {
            try
            {
                return await _microContext.Servicos.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Servicos> GetServicoByNomeAsync(string nome)
        {
            try
            {
                return await _microContext.Servicos.FirstOrDefaultAsync(s => s.NomeServico == nome);
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }

        public async Task<Servicos> UpdateServicoAsync(Servicos servico)
        {
            try
            {
                _microContext.Entry(servico).State = EntityState.Modified;
                await _microContext.SaveChangesAsync();
                return servico;
            }
            catch (Exception ex)
            {
                // Manipular exceção aqui (log, lançar, etc.)
                throw;
            }
        }
    }

}
