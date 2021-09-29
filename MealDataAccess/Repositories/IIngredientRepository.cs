using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;

namespace MealDataAccess.Repositories
{
    public interface IIngredientRepository : IRepository<IngredientsDBModel>
    {
        Task<IEnumerable<IngredientsDBModel>> GetAllAsync();
        Task<int> AddAsync(String IngredientInfoList);
    }
}
