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
                return Ok(_ingredientService.GetAllIngredients());
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
    }
}