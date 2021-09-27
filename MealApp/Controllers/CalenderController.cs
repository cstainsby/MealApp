﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            IRecipeRepository recipeRepository = UnitOfWork.RecipeRepo;

            var recipes = recipeRepository.GetAllAsync();

            return View(recipes);
        }
    }
}
