﻿using Shop.Database;
using Shop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin {
    public class UpdateStock {
        private ApplicationDbContext _context;

        public UpdateStock(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Response> DoAsync(Request request) {
            var stocks = new List<Stock>();

            foreach (var stock in request.Stock) {
                stocks.Add(new Stock() {
                    Id = stock.Id,
                    Description = stock.Description,
                    Qty = stock.Qty,
                    ProductId = stock.ProductId
                });
            }

            _context.UpdateRange(stocks);

            await _context.SaveChangesAsync();

            return new Response() {
                Stock = request.Stock
            };
        }
        public class StockViewModel {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }

        public class Request {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}
