using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;
using ProductApp.WebApi.ViewModels;

namespace ProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("products")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if (products.Count() != 0)
            {
                var productsViewModel = new List<ProductViewModel>();
                foreach (var product in productsViewModel)
                {
                    productsViewModel.Add(_mapper.Map<ProductViewModel>(product));
                }
                return Ok(productsViewModel);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product is not null)
            {
                var productViewModel = _mapper.Map<ProductViewModel>(product);
                return Ok(productViewModel);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateProduct([FromForm] ProductViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            var product = _mapper.Map<Product>(entity);

            var result = await _productRepository.CreateProduct(product);
            if (result != false)
            {
                return Created($"/appointment/{entity.Id}", entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (await _productRepository.GetProduct(id) is null)
            {
                return BadRequest();
            };

            var result = await _productRepository.DeleteProduct(id);
            if (result != false)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
