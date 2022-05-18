using etTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;


        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Produto).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();



            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProdutoId = item.Produtos.Id,
                    OrderId = order.Id,
                    Valor = item.Produtos.Valor,

                };
                await _context.OrderItems.AddAsync(orderItem);

            }

            await _context.SaveChangesAsync();


        }

        public async Task<OrderItem> GetQntdOrderByIdAsync(OrderItem data, int id)
        {
            var dbAmount = await _context.OrderItems.FirstOrDefaultAsync(n => n.Id == id);
            dbAmount.Amount = data.Amount;

            return dbAmount;
        }
    }
}