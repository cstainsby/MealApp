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
                var DBingredients = await ingredientRepository.GetByIdAsync(recipe.IdOfIngredients);
                var DBnutrition = await nutritionFactRepo.GetByIdAsync(recipe.IdOfNutritionFacts);

                recipesList.Append(new Recipe(
                    recipe.Name, 
                    new IngredientList().readDBEquivalent(DBingredients),
                    new NutritionFacts().readDBEquivalent(DBnutrition),
                    recipe.WebsiteUrl
                    ));
            }

            return View(recipesList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe model)
        {
            // prevent spoofing check
            if (ModelState.IsValid)
            {

                // get recipe repository and all repositories of other object that it depends on
                IRecipeRepository recipeRepository = UnitOfWork.RecipeRepo;
                IIngredientRepository ingredientRepository = UnitOfWork.IngredientRepo;
                INutritionRepository nutritionFactRepo = UnitOfWork.NutritionRepo;

                /*int resultRecipe = await recipeRepository.AddAsync(
                    );

                UnitOfWork.Save();

                if (resultRecipe > 0 &&)
                {
                    return RedirectToAction("Index", "Workshop");
                }*/
            }

            return StatusCode(500, new { Message = "Error Adding Item" });
        }
    }
}
