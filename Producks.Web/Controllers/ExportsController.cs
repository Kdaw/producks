﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producks.Data;
using Producks.Web.Models;

namespace Producks.Web.Controllers
{
    [ApiController]
    public class ExportsController : ControllerBase
    {
        private readonly StoreDb _context;

        public ExportsController(StoreDb context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet("api/Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Brands
                                       .Select(b => new BrandDto
                                       {
                                           Id = b.Id,
                                           Name = b.Name,
                                           Active = b.Active
                                       })
                                       .ToListAsync();
            return Ok(brands);
        }

        // GET: api/Categories
        [HttpGet("api/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                                            .Select(c => new CategoryDto
                                            {
                                                Id = c.Id,
                                                Name = c.Name,
                                                Description = c.Description,
                                                Active = c.Active
                                            })
                                            .ToListAsync();
            return Ok(categories);
        }

        //GET api/Products
        [HttpGet("api/Products/{category}")]
        public async Task<IActionResult> GetProducts(int? categoryId = null, int? brandId = null, int? priceMin = null, int? priceMax = null)
        {
            var products = await _context.Products
                                            .Select(p => new ProductDto
                                            {
                                                Id = p.Id,
                                                CategoryId = p.CategoryId,
                                                BrandId = p.BrandId,
                                                Name = p.Name,
                                                Description = p.Description,
                                                Price = p.Price
                                            })
                                            .Where(prod => (categoryId == null || prod.CategoryId == categoryId)
                                                            && (brandId == null || prod.BrandId == brandId)
                                                            && (priceMin == null || prod.Price >= priceMin)
                                                            && (priceMax == null || prod.Price <= priceMax)
                                            )
                                            .ToListAsync();
            return Ok(products);
        }
    }
}
