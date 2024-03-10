using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Services;
using RecipeBook.Domain.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("RecipeController")]
    public class RecipeBookController : ControllerBase
    {
        private readonly RecipeBookService _recipeBookService;

        public RecipeBookController(RecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        private readonly Recipe recipe = new() { Id = 1, Name = "Banana pancakes" };

        //[HttpGet]
        //[Route("TestAPI")]
        //public async Task<IActionResult> Test()
        //{
        //    return Ok(recipe);
        //}

        [HttpGet]
        [Route("GetRecipe/{Id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            try
            {
                return Ok(await _recipeBookService.GetRecipeById(id));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("PostRecipe")]
        public async Task<IActionResult> PostRecipe(string name)
        {
            try
            {
                return Ok(_recipeBookService.CreateRecipe(new Recipe() { Name = name }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("PostIngredient")]
        public async Task<IActionResult> PostIngredient(string name)
        {
            try
            {
                return Ok(_recipeBookService.CreateIngredient(new Ingredient { Name = name }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }
    }
}