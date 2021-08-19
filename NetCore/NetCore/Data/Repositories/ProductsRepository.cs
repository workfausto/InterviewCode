using Microsoft.AspNetCore.Mvc;
using NetCore.Core.Models;
using NetCore.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetCore.Data.Repositories
{
    public class ProductsRepository: ControllerBase,IProducts
    {
        EFContext _dbContext;
        public ProductsRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Products[] GetProducts() {
            return _dbContext.Products.ToArray();
        }

        public Products GetProductByID(int ProductId) {
            return _dbContext.Products.Find(ProductId);
                    
        }

        public async Task<IActionResult> InsertProduct(Products product) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return Ok(new { error = false, message = "The product was successfully inserted." });
            }
            catch
            {
                return BadRequest(new { error = true, message = "An error ocurred." });
            }
            
        }

        public async Task<IActionResult> DeleteProduct(int ProductId) {
            try { 
                var obj = await _dbContext.Products.FindAsync(ProductId);
                if(obj == null)
                {
                    return NotFound(new { error = true, message = "Product not found" });
                }
                _dbContext.Products.Remove(obj);
                await _dbContext.SaveChangesAsync();
                return Ok(new { error = false, message = "The product was successfully deleted." });
            }
            catch
            {
                return BadRequest(new { error = true, message = "An error ocurred." });
            }
        }

        public async Task<IActionResult> UpdateProduct(Products products)
        {
            try
            {
                var obj = await _dbContext.Products.FindAsync(products.Id);
                if (obj == null)
                {
                    return NotFound(new { error = true, message = "Product not found" });
                }
                JsonConvert.PopulateObject(JsonConvert.SerializeObject(products), obj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    if (!Exist(obj.Id))
                    {
                        return NotFound(new { error = true, message = "Product not found" });
                    }
                    else
                    {
                        return BadRequest(new { error = true, message = "An error ocurred." });
                    }
                }

                return Ok(new { error = false, message = "The product was successfully updated." });
            }
            catch
            {
                return BadRequest(new { error = true, message = "An error ocurred." });
            }
        }

        public bool Exist(int id)
        {
            return _dbContext.Products.Any(e => e.Id == id);
        }
    }
}
