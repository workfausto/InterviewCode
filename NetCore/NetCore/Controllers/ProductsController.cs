using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCore.Core.Models;
using NetCore.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{

    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        IProducts _products;

        public ProductsController(IProducts products){
            _products = products;
        }

        [HttpGet]
        [Route("GetProducts")]
        public Products[] GetProducts() {
            return _products.GetProducts();
        }

        [HttpGet]   
        [Route("GetProductByID/{ProductId}")]
        public Products GetProductByID(int ProductId) {
            return _products.GetProductByID(ProductId);
        }

        [HttpPost]
        [Route("InsertProduct")]
        public Task<IActionResult> InsertProduct(Products product) {
            return _products.InsertProduct(product);
        }

        [HttpDelete]
        [Route("DeleteProduct/{ProductId}")]
        public Task<IActionResult> DeleteProduct(int ProductId) {
            return _products.DeleteProduct(ProductId);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public Task<IActionResult> UpdateProduct(Products products) {
            return _products.UpdateProduct(products);
        }
    }
}
