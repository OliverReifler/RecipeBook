﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("UserController")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IRecipeBookService _recipeBookService;

        public UserController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        //private int _userId =>
        //    Convert.ToInt32(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        [HttpGet("GetLatest")]
        public async Task<ApiResponse<IEnumerable<Recipe>>> GetLatestRecipes(int count)
        {
            try
            {
                return ApiResponse<IEnumerable<Recipe>>.Success(await _recipeBookService.GetLatestRecipes(count));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<Recipe>>.Fail(ex.Message); }
        }
    }
}