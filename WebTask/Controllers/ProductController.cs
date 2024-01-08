﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTask.Models;
using WebTask.Services;

namespace WebTask.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody]Product product,int id)
        {
            _productService.Update(product, id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _productService.Add(product);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
