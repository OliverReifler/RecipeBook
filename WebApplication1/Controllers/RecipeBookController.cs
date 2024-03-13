using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("RecipeController")]
    public class RecipeBookController : ControllerBase
    {
        private readonly IRecipeBookService _recipeBookService;

        public RecipeBookController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        private readonly Recipe recipe1 = new() { Id = 1, Name = "Banana pancakes" };

        [HttpGet]
        [Route("TestAPI")]
        public Recipe Test()
        {
            return recipe1;
        }

        [HttpPost]
        [Route("AddIngredientToRecipe")]
        public async Task<IActionResult> AddIngredientToRecipe(string ingredient, string recipe)
        {
            try
            {
                return Ok(await _recipeBookService.AddIngredientToRecipe(ingredient, recipe));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetRecipe")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            try
            {
                return Ok(await _recipeBookService.GetRecipeByIdAsync(id));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("PostRecipe")]
        public async Task<IActionResult> PostRecipe(string name)
        {
            try
            {
                return Ok(await _recipeBookService.CreateRecipe(new Recipe() { Name = name }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("PostIngredient")]
        public async Task<IActionResult> PostIngredient(string name)
        {
            try
            {
                return Ok(await _recipeBookService.CreateIngredientAsync(new Ingredient { Name = name }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }
    }
}