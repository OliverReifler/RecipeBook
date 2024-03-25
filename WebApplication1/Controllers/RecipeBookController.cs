using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Extentions;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("RecipeBookController")]
    public class RecipeBookController : ControllerBase
    {
        private readonly IRecipeBookService _recipeBookService;
        private readonly IIngredientService _ingredientService;
        private readonly ITagService _tagService;

        public RecipeBookController(IRecipeBookService recipeBookService, IIngredientService ingredientService, ITagService tagService)
        {
            _recipeBookService = recipeBookService;
            _ingredientService = ingredientService;
            _tagService = tagService;
        }

        [HttpGet]
        [Route("GetRecipe")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            try
            {
                Recipe recipe = await _recipeBookService.GetRecipeByIdAsync(id);
                RecipeDto recipeDto = recipe.MapToRecipeDto();
                return Ok(recipeDto);
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpGet]
        [Route("GetAllRecipes")]
        public async Task<ApiResponse<IEnumerable<Recipe>>> GetAllRecipes()
        {
            try
            {
                return ApiResponse<IEnumerable<Recipe>>.Success(await _recipeBookService.GetAllRecipes());
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<Recipe>>.Fail(ex.Message); }
        }

        //[HttpGet]
        //[Route("GetAllRecipes")]
        //public async Task<IActionResult> GetAllRecipes()
        //{
        //    try
        //    {
        //        return Ok(await _recipeBookService.GetAllRecipes());
        //    }
        //    catch (ArgumentException x) { return BadRequest(x.Message); }
        //}

        [HttpPost]
        [Route("PostRecipe")]
        public async Task<IActionResult> PostRecipe(string name, List<Ingredient>? ingredients)
        {
            try
            {
                return Ok(await _recipeBookService.CreateRecipeAsync(new Recipe() { Name = name, Ingredients = ingredients }));
            }
            catch (ArgumentException x) { return BadRequest(x.Message); }
        }

        [HttpPost]
        [Route("AddIngredientToRecipe")]
        public async Task<IActionResult> AddIngredientToRecipe(int ingredientId, int recipeId)
        {
            try
            {
                Ingredient ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);
                Recipe recipe = await _recipeBookService.GetRecipeByIdAsync(recipeId);
                recipe.Ingredients.Add(ingredient);
                await _recipeBookService.UpdateRecipeAsync(recipe);
                return Ok(recipe);
            }
            catch (Exception ex) { return BadRequest(new ArgumentException(ex.Message)); }
        }

        [HttpPost]
        [Route("AddTagToRecipe")]
        public async Task<IActionResult> AddTagToRecipe(int tagId, int recipeId)
        {
            try
            {
                Tag tag = await _tagService.GetByIdAsync(tagId);
                Recipe recipe = await _recipeBookService.GetRecipeByIdAsync(recipeId);
                recipe.Tags.Add(tag);
                await _recipeBookService.UpdateRecipeAsync(recipe);
                return Ok(recipe);
            }
            catch (Exception ex) { return BadRequest(new ArgumentException(ex.Message)); }
        }
    }
}