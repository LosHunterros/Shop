﻿using Shop.Database;
using System.Linq;

namespace Shop.Application.ProductsAdmin {
    public class GetProduct {
        private ApplicationDbContext _context;

        public GetProduct(ApplicationDbContext context) {
            _context = context;
        }

        public ProductViewModel Do(int id) => _context.Products.Where(x => x.Id == id).Select(x => new ProductViewModel {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Value = x.Value
        }).FirstOrDefault();

        public class ProductViewModel {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
