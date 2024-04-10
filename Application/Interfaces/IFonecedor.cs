using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFornecedor
    {
        Task<Fornecedores> GetFornecedorByIdAsync(int id);
        Task<Fornecedores> GetFornecedorByNameAsync(string nome);
        Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync();
        Task<Fornecedores> CreateFornecedorAsync(Fornecedores fornecedor);
        Task<Fornecedores> UpdateFornecedorAsync(Fornecedores fornecedor);
        Task DeleteFornecedorAsync(int id);
    }
}
