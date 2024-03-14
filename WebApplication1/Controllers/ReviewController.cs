using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("ReviewController")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IRecipeBookService _recipeBookService;

        public ReviewController(IReviewService reviewservice, IRecipeBookService recipeBookService)
        {
            _reviewService = reviewservice;
            _recipeBookService = recipeBookService;
        }

        [HttpPost]
        [Route("PostReview")]
        public async Task<IActionResult> CreateReview(int recipeId, List<Person>? personlist, string? reviewtext)
        {
            try
            {
                Review review = new() { ReviewText = reviewtext, Persons = personlist };
                await _reviewService.CreateReviewAsync(review);
                Recipe recipe = await _recipeBookService.GetRecipeByIdAsync(recipeId);
                recipe.Reviews.Add(review);
                await _recipeBookService.UpdateRecipeAsync(recipe);
                return Ok(review);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetReviewById")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {
                return Ok(_reviewService.GetReviewByIdAsync(id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                return Ok(_reviewService.GetAllReviews());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}