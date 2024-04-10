using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServico
    {
        Task<Servicos> GetServicoByIdAsync(int id);
        Task<IEnumerable<Servicos>> GetAllServicosAsync();
        Task<Servicos> CreateServicoAsync(Servicos servico);
        Task<Servicos> UpdateServicoAsync(Servicos servico);
        Task DeleteServicoAsync(int id);
    }
}
