using Microsoft.AspNetCore.Mvc;
using NetCore.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Data.Migrations
{
    public interface IProducts
    {
        public Products[] GetProducts();

        public Products GetProductByID(int ProductId);

        public Task<IActionResult> InsertProduct(Products product);

        public Task<IActionResult> DeleteProduct(int ProductId);

        public Task<IActionResult> UpdateProduct(Products products);
    }
}
