using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEntradaEstoque
    {
        Task<EntradaEstoque> GetEntradaEstoqueByIdAsync(int id);
        Task<IEnumerable<EntradaEstoque>> GetAllEntradasEstoqueAsync();
        Task<EntradaEstoque> CreateEntradaEstoqueAsync(EntradaEstoque entradaEstoque);
        Task<EntradaEstoque> UpdateEntradaEstoqueAsync(EntradaEstoque entradaEstoque);
        Task DeleteEntradaEstoqueAsync(int id);
    }
}
