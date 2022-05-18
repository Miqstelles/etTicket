using etTicket.Data;
using etTicket.Data.Services;
using etTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutosService _service;

        public ProdutosController(IProdutosService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProdutos = await _service.GetAllAsync();
            return View(allProdutos);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProdutos = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProdutos.Where(n => n.NomeProduto.Contains(searchString) || n.Descrição.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allProdutos);
        }

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var produtoDetail = await _service.GetProdutoByIdAsync(id);
            return View(produtoDetail);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NovoProdutoVM produto)
        {


            await _service.AddNewProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var produtoDetails = await _service.GetProdutoByIdAsync(id);
            if (produtoDetails == null) return View("NotFound");

            var response = new NovoProdutoVM()
            {
                Id = produtoDetails.Id,
                NomeProduto = produtoDetails.NomeProduto,
                Descrição = produtoDetails.Descrição,
                Valor = produtoDetails.Valor,
                ImageURL = produtoDetails.ImageURL,
                Quantidade = produtoDetails.Quantidade
            };


            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NovoProdutoVM produto)
        {
            if (id != produto.Id) return View("NotFound");

            await _service.UpdateProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        //Get: Produtos/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var produtosDetails = await _service.GetByIdAsync(id);
            if (produtosDetails == null) return View("NotFound");
            return View(produtosDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtosDetails = await _service.GetByIdAsync(id);
            if (produtosDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
