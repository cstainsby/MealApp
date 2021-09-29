using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Models
{
    public class IngredientsDBModel : AbstractProjectDBModel
    {
        public String JSONIngredientList { get; set; }
        public IngredientsDBModel(String JSONIngredientList)
        {
            this.JSONIngredientList = JSONIngredientList;
        }
    }
}
