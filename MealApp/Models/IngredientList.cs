using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace MealApp.Models
{
    public class IngredientList : IStoreableModel<IngredientList, MealDataAccess.Models.IngredientsDBModel>
    {
        public List<Ingredient> Ingredients { get; set; }


        public IngredientList()
        {

        }

        public IngredientList readDBEquivalent(MealDataAccess.Models.IngredientsDBModel ingredientsDBModel)
        {
            String ingredientsJSON = ingredientsDBModel.JSONIngredientList;

            this.Ingredients = JsonSerializer.Deserialize<List<Ingredient>>(ingredientsJSON);

            return this;
        }
    }
}
