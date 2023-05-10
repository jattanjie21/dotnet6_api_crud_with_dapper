using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models;
using RecipeAPI.Services.Interfaces;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    { 
        private readonly IRecipeServices _recipeServices;
        public RecipeController(IRecipeServices recipeServices) 
        {
            _recipeServices = recipeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            try
            {
                var recipes = await _recipeServices.GetAllRecipes();

                return Ok(recipes);
            }
            catch (Exception error)
            {
                return StatusCode(500, $"An error occured while getting all recipes: {error.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
        {
            try
            {
                var recipeObject = await _recipeServices.CreateRecipe(recipe);

                return Ok(recipeObject);
            }
            catch (Exception error)
            {
                return StatusCode(500, $"An error occured while creating recipe: {error.Message}");
            }
        }
    }
}
