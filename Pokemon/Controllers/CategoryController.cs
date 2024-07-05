using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Dto;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper _mapper;
         
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(categoryRepository.GetCategories());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200,Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategroy(int categoryId)
        {
            if (!categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(categoryRepository.GetCategory(categoryId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("{categoryId}/Pokemon")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<global::Pokemon.Models.Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(categoryRepository.getPokemonsByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            var category = categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryDto.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(category != null)
            {
                ModelState.AddModelError("", "category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryCreate = _mapper.Map<Category>(categoryDto);

            if(!categoryRepository.CreateCategory(categoryCreate))
            {
                ModelState.AddModelError("", "something went wrong while creating the category");
                return StatusCode(500,ModelState);
            }

            return Ok("successfully created");
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody]CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            if (categoryId != categoryDto.Id)
                return BadRequest(ModelState);

            if(!categoryRepository.CategoryExists(categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var map = _mapper.Map<Category>(categoryDto);

            if(!categoryRepository.UpdateCategory(map))
            {
                ModelState.AddModelError("", "something went wrong while updaing the category");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully updated");
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if(!categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }

            var categoryToDelete = categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!categoryRepository.DeleteCategory(categoryToDelete))
            {
                ModelState.AddModelError("", "something went wrong while deleteing the category");
                return BadRequest(ModelState);
            }

            return Ok("deleted successfully");
        }

    }
}
