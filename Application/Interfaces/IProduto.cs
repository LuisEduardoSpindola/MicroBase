using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProduto
    {
        Task<Produto> GetProductByIdAsync(int Id);
        Task<Produto> GetProductByNameAsync(string Nome);
        Task<Produto> GetProductByEanAsync(int Ean);
        Task<IEnumerable<Produto>> GetAllProductsAsync();
        Task<Produto> CreateProductAsync(Produto produto);
        Task<Produto> UpdateProductAsync(Produto produto);
        Task DeleteProductAsync(int Id);
    }
}
