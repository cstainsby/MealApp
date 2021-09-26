using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class Ingredient
    {
        public String IngredientName { get; set; }

        public double Ammount { get; set; }


        public String MeasurementType { get; set; }

        public Ingredient()
        {
            IngredientName = null;
            Ammount = -1;
            MeasurementType = null;
        }
    }
}