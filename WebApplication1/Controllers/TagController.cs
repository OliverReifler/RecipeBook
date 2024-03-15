using Microsoft.AspNetCore.Mvc;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("TagController")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        [Route("PostTag")]
        public async Task<IActionResult> PostTag(string title)
        {
            try
            {
                Tag tag = new() { Title = title };
                return Ok(await _tagService.CreateTagAsync(tag));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            try
            {
                return Ok(await _tagService.GetByIdAsync(id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                return Ok(await _tagService.GetAllTagsAsync());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}