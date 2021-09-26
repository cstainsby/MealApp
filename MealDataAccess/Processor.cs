using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;

namespace MealDataAccess
{
    public static class Processor
    {
        public static RecipeDBModel processSimulation(String Name, int OwnerId, int IdOfNutritionFacts, int IdOfIngrdients, String WebsiteUrl)
        {
            // create new recipe
            RecipeDBModel newRecipe = new RecipeDBModel(Name, OwnerId, IdOfNutritionFacts, IdOfIngrdients, WebsiteUrl);

            return newRecipe;
        }
    }
}
