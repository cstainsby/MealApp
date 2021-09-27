using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;
using Dapper;
using System.Data;

namespace MealDataAccess.Repositories
{
    internal class IngredientRepository : Repository<IngredientsDBModel>, IIngredientRepository
    {
        public IngredientRepository(IDbTransaction _transaction) : base(_transaction)
        {
            _type = "Recipe";
        }

        // retrieve all items of type RecipeDBModel within the db 
        public async Task<IEnumerable<IngredientsDBModel>> GetAllAsync()
        {
            string sql = @"SELECT Id, Name, OwnerId, IdOfNutritionFacts, IdOfIngrdients, WebsiteUrl FROM MealAppDB." + _type;

            return await _connection.QueryAsync<IngredientsDBModel>(sql, transaction: _transaction);
        }

        // create a new item of type RecipeDBModel within db given Id
        public async Task<int> AddAsync(String JSONIngredientsList)
        {
            IngredientsDBModel entity = new IngredientsDBModel(JSONIngredientsList);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            string sql = @"INSERT INTO MealAppDB." + _type + " (JSONIngredientList) VALUES(@JSONIngredientsList);";

            sql = sql.Replace("@JSONIngredientsList", $"'{entity.JSONIngredientList}'");

            int rowsAffected = await _connection.ExecuteAsync(sql, entity, transaction: _transaction);

            return rowsAffected;
        }
    }
}
