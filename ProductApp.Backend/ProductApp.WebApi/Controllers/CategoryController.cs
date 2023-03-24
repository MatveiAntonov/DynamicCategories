using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Interfaces;
using ProductApp.WebApi.ViewModels;

namespace ProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("categories")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            if (categories.Count() != 0)
            {
                var categoriesViewModel = new List<CategoryViewModel>();
                foreach (var category in categories)
                {
                    categoriesViewModel.Add(_mapper.Map<CategoryViewModel>(category));
                }
                return Ok(categoriesViewModel);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<CategoryViewModel>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category is not null)
            {
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                return Ok(categoryViewModel);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCategory([FromForm] CategoryViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            var category = _mapper.Map<Category>(entity);

            var result = await _categoryRepository.CreateCategory(category);
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
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (await _categoryRepository.GetCategory(id) is null)
            {
                return BadRequest();
            };

            var result = await _categoryRepository.DeleteCategory(id);
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
