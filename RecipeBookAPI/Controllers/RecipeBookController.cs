using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;

namespace RecipeBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBookController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Recipe> Recipes()
        {
            return [];
        }
    }
}