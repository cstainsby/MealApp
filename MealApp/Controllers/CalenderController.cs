using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Repositories;

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
            List<Models.Recipe> recipesList = new List<Models.Recipe>();

            // get recipe repository and all repositories of other object that it depends on
            IRecipeRepository recipeRepository = UnitOfWork.RecipeRepo;
            IRecipeRepository ingredientRepository = UnitOfWork.IngredientRepo;
            IRecipeRepository nutritionFactRepo = UnitOfWork.IngredientRepo;

            var DBrecipes = await recipeRepository.GetAllAsync();

            foreach (var recipe in DBrecipes)
            {
                recipesList.Append(new Models.Recipe(
                    recipe.Name, 
                    recipe.
                    recipe.WebsiteUrl
                    ));
            }

            return View(recipesList);
        }
    }
}
