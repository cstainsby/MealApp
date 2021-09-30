using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIClientManager;
using APIClientManager.Models;

namespace MealApp.Controllers
{
    public class RecipeFinderController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var recipeAPIModel = await RecipeAPIProcessor.GetListAsync();


            return View(recipeAPIModel);
        }
    }
}
