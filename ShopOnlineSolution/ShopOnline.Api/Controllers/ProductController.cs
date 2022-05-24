using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                IEnumerable<Product> products =await  this.productRepository.GetProducts();
                IEnumerable<ProductCategory> categories = await this.productRepository.GetCategories();
                if(products==null || categories == null)
                {
                    return NotFound();
                }
                else
                {
                    IEnumerable<ProductDto> productDtos = products.GetProductDtos(categories);
                    return Ok(productDtos);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }
        }
    }
}
