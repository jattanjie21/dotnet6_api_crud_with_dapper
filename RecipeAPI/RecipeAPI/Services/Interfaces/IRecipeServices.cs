using RecipeAPI.Models;

namespace RecipeAPI.Services.Interfaces
{
    public interface IRecipeServices
    {
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe> CreateRecipe(Recipe recipe);
    }
}
