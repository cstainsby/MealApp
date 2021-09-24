using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class Recipe
    {
        public String Name { get; set; }
        public String Ingredients { get; set; }
        public NutritionFacts NutritionFacts { get; set; }
    }
}
