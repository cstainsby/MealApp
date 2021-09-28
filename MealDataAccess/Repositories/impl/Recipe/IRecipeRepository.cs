using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;

namespace MealDataAccess.Repositories
{
    public interface IRecipeRepository : IRepository<RecipeDBModel>
    {
        Task<IEnumerable<RecipeDBModel>> GetAllAsync();
        Task<int> AddAsync(String Name, int OwnerId, int IdOfNutritionFacts, int IdOfIngrdients, String WebsiteUrl);
    }
}
