using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("GetAllIngredients")]
        public async Task<IActionResult> GetAllIngredients()
        {
            try
            {
                return Ok(await _ingredientService.GetAllIngredients());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetIngredientById")]
        public async Task<IActionResult> GetIngredientById(int id)
        {
            try
            {
                return Ok(await _ingredientService.GetIngredientByIdAsync(id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        [Route("PostIngredient")]
        public async Task<IActionResult> PostIngredient(string name)
        {
            Ingredient ingredient = new() { Name = name };
            try
            {
                return Ok(await _ingredientService.CreateIngredientAsync(ingredient));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //[HttpPost]
        //[Route("AddIngredientToRecipe")]
        //public async Task<IActionResult> UpdateIngredient(int ingredientId, int recipeId)
        //{
        //    try
        //    {
        //        Ingredient ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);
        //        ingredient.RecipeId.Add(recipeId);
        //        await _ingredientService.UpdateIngredient(ingredient);
        //        return Ok(ingredient);
        //    }
        //    catch (Exception ex) { return BadRequest(new ArgumentException(ex.Message)); }
        //}
    }
}