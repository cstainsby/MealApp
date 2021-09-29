using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class NutritionFacts : IStoreableModel<NutritionFacts, MealDataAccess.Models.NutritionDBModel>
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

        public NutritionFacts()
        {

        }

        public NutritionFacts readDBEquivalent(MealDataAccess.Models.NutritionDBModel dBModel) 
        {
            this.Calories = dBModel.Calories;
            this.Carbohydrates_g = dBModel.Carbohydrates_g;
            this.Protein_g = dBModel.Protein_g;
            this.Fats_Total_g = dBModel.Fats_Total_g;

            return this;
        }
    }
}
