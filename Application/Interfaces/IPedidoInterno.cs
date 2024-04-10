using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoInterno
    {
        Task<PedidoInterno> GetPedidoInternoByIdAsync(int id);
        Task<IEnumerable<PedidoInterno>> GetAllPedidosInternosAsync();
        Task<PedidoInterno> CreatePedidoInternoAsync(PedidoInterno pedidoInterno);
        Task<PedidoInterno> UpdatePedidoInternoAsync(PedidoInterno pedidoInterno);
        Task DeletePedidoInternoAsync(int id);
    }
}
