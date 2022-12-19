using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await productRepository.GetProducts());
        }
        [HttpGet]
        [Route("Getproduct")]
        public async Task<IActionResult> getProduct(int id)
        {
            return Ok(await productRepository.GetProductById(id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await productRepository.Add(product);
            return Ok("Added successfully!");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result= await productRepository.Update(product);
            return Ok("Updated successfully!");
        }
        [HttpDelete]
        [Route("Remove")]
        public JsonResult Remove(int id)
        {
            productRepository.Delete(id);
            return new JsonResult("Delete Successfully!");
        }
    }
}
