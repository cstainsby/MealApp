using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MealApp.Models
{
    public class Recipe 
    {
        [Display(Name="Recipe Name")]
        public String Name { get; set; }

        [Display(Name="Ingredients")]
        public IngredientList Ingredients { get; set; }

        [Display(Name="Nutrition Facts")]
        public NutritionFacts NutritionFacts { get; set; }

        [Display(Name="Url to Website")]
        public String UrlToWebstie { get; set; }

        public Recipe()
        {
            Name = null;
            Ingredients = new IngredientList();
            NutritionFacts = new NutritionFacts();
            UrlToWebstie = null;
        }

        public Recipe(String Name, IngredientList Ingredients, NutritionFacts Nutrition, String UrlToWebsite)
        {
            this.Name = Name;
            this.Ingredients = Ingredients;
            this.NutritionFacts = NutritionFacts;
            this.UrlToWebstie = UrlToWebstie;
        }
    }
}
