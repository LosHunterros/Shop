﻿using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.ProductsAdmin {
    public class GetProducts {
        private ApplicationDbContext _context;

        public GetProducts(ApplicationDbContext context) {
            _context = context;
        }

        public IEnumerable<ProductViewModel> Do() => _context.Products.ToList().Select(x => new ProductViewModel {
            Id = x.Id,
            Name = x.Name,
            Value = x.Value
        });

        public class ProductViewModel {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
    }
}
