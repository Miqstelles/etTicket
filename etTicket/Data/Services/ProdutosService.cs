using etTicket.Data.Base;
using etTicket.Data.ViewModels;
using etTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Data.Services
{
    public class ProdutosService : EntityBaseRepository<Produtos>, IProdutosService
    {
        private readonly AppDbContext _context;


        OrderItem o = new OrderItem();

        public ProdutosService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProdutoAsync(NovoProdutoVM data)
        {
            var newProduto = new Produtos()
            {
                NomeProduto = data.NomeProduto,
                Descrição = data.Descrição,
                Valor = data.Valor,
                ImageURL = data.ImageURL,
                Quantidade = data.Quantidade
            };
            await _context.Produtos.AddAsync(newProduto);
            await _context.SaveChangesAsync();

        }

        public async Task<Produtos> GetProdutoByIdAsync(int id)
        {
            var produtosDetails = await _context.Produtos.FirstOrDefaultAsync(n => n.Id == id);

            return produtosDetails;
        }

        public async Task UpdateProdutoAsync(NovoProdutoVM data)
        {
            var dbProduto = await _context.Produtos.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduto != null)
            {

                dbProduto.NomeProduto = data.NomeProduto;
                dbProduto.Descrição = data.Descrição;
                dbProduto.Valor = data.Valor;
                dbProduto.ImageURL = data.ImageURL;
                dbProduto.Quantidade = data.Quantidade;
                await _context.SaveChangesAsync();
            }
        }

    }
}
