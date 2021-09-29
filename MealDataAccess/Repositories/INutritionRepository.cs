using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;

namespace MealDataAccess.Repositories
{
    public interface INutritionRepository : IRepository<NutritionDBModel>
    {
        Task<IEnumerable<NutritionDBModel>> GetAllAsync();
        Task<int> AddAsync(int Calories, int Protein_g, int Carbohydrates_g, int Fats_Total_g);
    }
}
