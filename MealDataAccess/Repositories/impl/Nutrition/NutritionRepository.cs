using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;
using System.Data;
using Dapper;

namespace MealDataAccess.Repositories
{
    internal class NutritionRepository : Repository<NutritionDBModel>, INutritionRepository
    {
        // possibly add a copy helper
        public NutritionRepository(IDbTransaction _transaction) : base(_transaction)
        {
            _type = "Nutrition";
        }

        // retrieve all items of type RecipeDBModel within the db 
        public async Task<IEnumerable<NutritionDBModel>> GetAllAsync()
        {
            string sql = @"SELECT Id, Calories, Protein_g, Carbohydrates_g, Fats_Total_g FROM MealAppDB." + _type;

            return await _connection.QueryAsync<NutritionDBModel>(sql, transaction: _transaction);
        }

        // create a new item of type RecipeDBModel within db given Id
        public async Task<int> AddAsync(int Calories, int Protein_g, int Carbohydrates_g, int Fats_Total_g)
        {
            NutritionDBModel entity = new NutritionDBModel(
                Calories,
                Protein_g,
                Carbohydrates_g,
                Fats_Total_g
            );

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            string sql = @"INSERT INTO MealAppDB." + _type + " (Calories, Protein_g, Carbohydrates_g, Fats_Total_g) VALUES(@Calories, @Protein_g, @Carbohydrates_g, @Fats_Total_g);";

            sql = sql.Replace("@Calories", $"'{entity.Calories}'");
            sql = sql.Replace("@Protein_g", $"'{entity.Protein_g}'");
            sql = sql.Replace("@Carbohydrates_g", $"'{entity.Carbohydrates_g}'");
            sql = sql.Replace("@Fats_Total_g", $"'{entity.Fats_Total_g}'");

            int rowsAffected = await _connection.ExecuteAsync(sql, entity, transaction: _transaction);

            return rowsAffected;
        }
    }
}
