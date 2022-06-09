using Pinegas.Data.Base;
using Pinegas.Data.ViewModels;
using Pinegas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinegas.Data.Services
{
    public interface IProdutosService : IEntityBaseRepository<Produtos>
    {

        Task<Produtos> GetProdutoByIdAsync(int id);
        Task AddNewProdutoAsync(NovoProdutoVM data);
        Task UpdateProdutoAsync(NovoProdutoVM data);
    }
}
