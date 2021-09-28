using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace MealDataAccess.Repositories
{
    internal class RecipeRepository : Repository<RecipeDBModel>, IRecipeRepository
    {
        // possibly add a copy helper
        public RecipeRepository(IDbTransaction _transaction) : base(_transaction)
        {
            _type = "Recipe";
        }

        // retrieve all items of type RecipeDBModel within the db 
        public async Task<IEnumerable<RecipeDBModel>> GetAllAsync()
        {
            string sql = @"SELECT Id, Name, OwnerId, IdOfNutritionFacts, IdOfIngrdients, WebsiteUrl FROM MealAppDB." + _type;

            return await _connection.QueryAsync<RecipeDBModel>(sql,transaction: _transaction);
        }

        // create a new item of type RecipeDBModel within db given Id
        public async Task<int> AddAsync(String Name, int OwnerId, int IdOfNutritionFacts, int IdOfIngrdients, String WebsiteUrl)
        {
            RecipeDBModel entity = new RecipeDBModel(
                Name, 
                OwnerId, 
                IdOfNutritionFacts, 
                IdOfIngrdients, 
                WebsiteUrl
            );

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            string sql = @"INSERT INTO MealAppDB." + _type + " (Name, OwnerId, IdOfNutritionFacts, IdOfIngrdients, WebsiteUrl) VALUES(@Name, @OwnerId, @IdOfNutritionFacts, @IdOfIngrdients, @WebsiteUrl);";

            sql = sql.Replace("@Name", $"'{entity.Name}'");
            sql = sql.Replace("@OwnerId", $"'{entity.OwnerId}'");
            sql = sql.Replace("@IdOfNutritionFacts", $"'{entity.IdOfNutritionFacts}'");
            sql = sql.Replace("@IdOfIngredients", $"'{entity.IdOfIngredients}'");
            sql = sql.Replace("@WebsiteUrl", $"'{entity.WebsiteUrl}'");

            int rowsAffected = await _connection.ExecuteAsync(sql, entity, transaction: _transaction);

            return rowsAffected;
        }
    }
}
