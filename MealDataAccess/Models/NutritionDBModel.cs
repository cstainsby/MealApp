using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Models
{
    public class NutritionDBModel : AbstractProjectDBModel
    {
        public int Calories { get; set; }
        // Macronutrients
        /*public int Fats_monoUnsat_g { get; set; }
        public int Fats_polyUnsat_g { get; set; }
        public int Fats_sat_g { get; set; }
        public int Fats_trans_g { get; set; }*/
        public int Protein_g { get; set; }
        public int Carbohydrates_g { get; set; }
        public int Fats_Total_g { get; set; }

        // TODO: uncomment for later implementation
        // Micronutrients
        /*public int Fiber_g { get; set; }
        public int Sugar_g { get; set; }
        public int Calcium_mg { get; set; }
        public int Cholestorol_mg { get; set; }
        public int Iron_mg { get; set; }
        public int Magnesium_mg { get; set; }
        public int Niacin_mg { get; set; }
        public int Phosphorus_mg { get; set; }
        public int Potassium_mg { get; set; }
        public int Riboflavin_mg { get; set; }
        public int Sodium_mg { get; set; }
        public int Thiamin_mg { get; set; }
        public int VitA_ug { get; set; }
        public int VitB12_ug { get; set; }
        public int VitB6_mg { get; set; }
        public int VitC_mg { get; set; }
        public int VitD_ug { get; set; }
        public int VitE_mg { get; set; }
        public int VitK_ug { get; set; }
        public int Zinc_mg { get; set; }*/

        public NutritionDBModel(int Calories, int Protein_g, int Carbohydrates_g, int Fats_Total_g)
        {
            this.Calories = Calories;
            this.Protein_g = Protein_g;
            this.Carbohydrates_g = Carbohydrates_g;
            this.Fats_Total_g = Fats_Total_g;
        }
    }
}
