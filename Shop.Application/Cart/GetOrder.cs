﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.Infrastructure;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Cart {
    public class GetOrder {
        private ISessionManager _sessionManager;

        public GetOrder(ISessionManager sessionManager) {
            _sessionManager = sessionManager;
        }

        public class Response {
            public IEnumerable<Product> Products { get; set; }
            public CustomerInformation CustomerInformation { get; set; }

            public int GetTotalCharge() => Products.Sum(x => x.Value * x.Qty);
        }

        public class Product {
            public int ProductId { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
            public int Value { get; set; }
        }

        public class CustomerInformation {
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
            public string Email { get; internal set; }
            public string PhoneNumber { get; internal set; }

            public string Address1 { get; internal set; }
            public string Address2 { get; internal set; }
            public string City { get; internal set; }
            public string PostCode { get; internal set; }
        }

        public Response Do() {
            var listOfProducts = _sessionManager
                .GetCart(x => new Product() {
                    ProductId = x.ProductId,
                    StockId = x.StockId,
                    Value = (int) (x.Value * 100),    // Payment value style
                    Qty = x.Qty
                });

            var customerInformation = _sessionManager.GetCustomerInformation();

            return new Response {
                Products = listOfProducts,
                CustomerInformation = new CustomerInformation {
                    FirstName = customerInformation.FirstName,
                    LastName = customerInformation.LastName,
                    Email = customerInformation.Email,
                    PhoneNumber = customerInformation.PhoneNumber,
                    Address1 = customerInformation.Address1,
                    Address2 = customerInformation.Address2,
                    City = customerInformation.City,
                    PostCode = customerInformation.PostCode
                }
            };
        }
    }
}
