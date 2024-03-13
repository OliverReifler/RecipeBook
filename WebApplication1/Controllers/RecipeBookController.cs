using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("RecipeBookController")]
    public class RecipeBookController : ControllerBase
    {
        private readonly IRecipeBookService _recipeBookService;

        public RecipeBookController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
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

        [HttpGet]
        [Route("GetAllRecipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            try
            {
                return Ok(await _recipeBookService.GetAllRecipes());
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("PostRecipe")]
        public async Task<IActionResult> PostRecipe(string name, List<string> ingredients)
        {
            try
            {
                return Ok(await _recipeBookService.CreateRecipeAsync(new Recipe() { Name = name }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        //[HttpPost]
        //[Route("PostIngredient")]
        //public async Task<IActionResult> PostIngredient(string name)
        //{
        //    try
        //    {
        //        return Ok(await _recipeBookService.CreateIngredientAsync(new Ingredient { Name = name }));
        //    }
        //    catch (ArgumentException x) { return BadRequest(x.Message); }
        //}
    }
}