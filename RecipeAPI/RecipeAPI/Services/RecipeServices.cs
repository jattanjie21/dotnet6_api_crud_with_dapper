using Dapper;
using Microsoft.Data.SqlClient;
using RecipeAPI.Models;
using RecipeAPI.Services.Interfaces;
using System.Data;

namespace RecipeAPI.Services
{
    public class RecipeServices : IRecipeServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public RecipeServices(IConfiguration configuration)
        {

            _configuration     = configuration;
            _connectionString  = _configuration.GetConnectionString("RecipeDB");

        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            var connection = CreateConnection();

            var insertSql = "INSERT INTO [Recipe].[dbo].[Recipe] " +
                    "(RecipeName, RecipeDescription) " +
                    "VALUES (@RecipeName, @RecipeDescription)";

            recipe = await connection.ExecuteScalarAsync<Recipe>(insertSql, recipe);

            return recipe;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var connection  = CreateConnection();

            var allMappings = await connection.QueryAsync<Recipe>("SELECT * FROM [Recipe].[dbo].[Recipe]");

            return (List<Recipe>)allMappings;
        }
    }
}
