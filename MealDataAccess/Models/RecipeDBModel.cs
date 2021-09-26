using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Models
{
    public class RecipeDBModel : AbstractProjectDBModel
    {
        // Name               -> Name of recipe
        // OwnerId            -> Id of the owner of the recipe
        // IdOfNutritionFacts -> Id pointing to the nutrition facts tied to this recipe
        // IdOfIngredients    -> Id pointing to the ingredients tied to this recipe
        // WebsiteUrl         -> url to website where the recipe was originally found

        public String Name { get; }
        public int OwnerId { get; } 
        public int IdOfNutritionFacts { get; }
        public int IdOfIngredients { get; }
        public String WebsiteUrl { get; }

        public RecipeDBModel(String Name, int OwnerId, int IdOfNutritionFacts, int IdOfIngredients,  String WebsiteUrl)
        {
            this.Name = Name;
            this.OwnerId = OwnerId;
            this.IdOfNutritionFacts = IdOfNutritionFacts;
            this.IdOfIngredients = IdOfIngredients;
            this.WebsiteUrl = WebsiteUrl;
        }
    }
}
