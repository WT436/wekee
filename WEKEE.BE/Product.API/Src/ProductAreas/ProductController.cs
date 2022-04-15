﻿using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        [Route("v1/api/cart-basic-product")]
        public async Task<IActionResult> GetBasicProduct(int input)
        {
            var data = await _product.GetBasicProductFroCart(id: input);
            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/cart-image-product")]
        public async Task<IActionResult> GetImageProduct(int input)
        {
            var data = await _product.GetImageProduct(id: input);
            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/cart-feature-product")]
        public async Task<IActionResult> GetFeatureProduct(int input)
        {
            var data = await _product.ProductCartRead(id: input);
            return Ok(data);
        }
    }
}