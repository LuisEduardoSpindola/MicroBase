using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrdemCompra
    {
        Task<OrdemCompra> GetOrdemCompraByIdAsync(int id);
        Task<IEnumerable<OrdemCompra>> GetAllOrdensCompraAsync();
        Task<OrdemCompra> CreateOrdemCompraAsync(OrdemCompra ordemCompra);
        Task<OrdemCompra> UpdateOrdemCompraAsync(OrdemCompra ordemCompra);
        Task DeleteOrdemCompraAsync(int id);
    }
}
