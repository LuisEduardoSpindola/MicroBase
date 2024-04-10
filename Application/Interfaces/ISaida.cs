using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaidaEstoque
    {
        Task<SaidaEstoque> GetSaidaEstoqueByIdAsync(int id);
        Task<IEnumerable<SaidaEstoque>> GetAllSaidasEstoqueAsync();
        Task<SaidaEstoque> CreateSaidaEstoqueAsync(SaidaEstoque saidaEstoque);
        Task<SaidaEstoque> UpdateSaidaEstoqueAsync(SaidaEstoque saidaEstoque);
        Task DeleteSaidaEstoqueAsync(int id);
    }
}
