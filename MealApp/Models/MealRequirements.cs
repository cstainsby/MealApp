using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class MealRequirements
    {
        public Person BuyingIngredients { get; set; }
        public Person CookingFood { get; set; }
        public int MealTime { get; set; }
        public int PreperationTime_m { get; set; }

        // maybe add how long the meal might take

    }
}
