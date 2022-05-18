using etTicket.Data.Base;
using etTicket.Data.ViewModels;
using etTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Data.Services
{
    public interface IProdutosService : IEntityBaseRepository<Produtos>
    {

        Task<Produtos> GetProdutoByIdAsync(int id);
        Task AddNewProdutoAsync(NovoProdutoVM data);
        Task UpdateProdutoAsync(NovoProdutoVM data);
    }
}
