﻿using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer;
using System.Threading.Tasks;

namespace Product.API.Src.CategoryProductAPI
{
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProduct _categoryProduct;
        public CategoryProductController(ICategoryProduct categoryProduct)
        {
            _categoryProduct = categoryProduct;
        }

        [HttpPost]
        [Route("/create-category")]
        public async Task<IActionResult> Index([FromBody] CategoryProductInsertDto categoryProductDto)
        {
            var data = await _categoryProduct.CreateCategory(cp: categoryProductDto);

            return Ok(data);
        }

        [HttpGet]
        [Route("/get-all")]
        public async Task<IActionResult> SelectAll(SearchOrderPageInput input)
        {
            var data = await _categoryProduct.GetAllPageListCategory(input: input);
            return Ok(data);
        }
    }
}
