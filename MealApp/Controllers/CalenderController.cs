using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Repositories;
using MealApp.Models;

namespace MealApp.Controllers
{
    public class CalenderController : Controller
    {
        private UnitOfWork UnitOfWork;

        public CalenderController(UnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            List<Recipe> recipesList = new List<Recipe>();

            // get recipe repository and all repositories of other object that it depends on
            IRecipeRepository recipeRepository = UnitOfWork.RecipeRepo;
            IIngredientRepository ingredientRepository = UnitOfWork.IngredientRepo;
            INutritionRepository nutritionFactRepo = UnitOfWork.NutritionRepo;

            var DBrecipes = await recipeRepository.GetAllAsync();

            foreach (var recipe in DBrecipes)
            {
                recipesList.Append(new Recipe(
                    recipe.Name, 
                    ingredientRepository.GetByIdAsync(recipe.IdOfIngredients),
                    new NutritionFacts().readDBEquivalent(await nutritionFactRepo.GetByIdAsync(recipe.IdOfNutritionFacts)),
                    recipe.WebsiteUrl
                    ));
            }

            return View(recipesList);
        }
    }
}
