using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;

namespace MealDataAccess.Repositories
{
    public interface IRecipeRepository : IRepository<RecipeModel>
    {
        Task<IEnumerable<RecipeModel>> GetAllAsync();
        Task<int> AddAsync();
    }
}
