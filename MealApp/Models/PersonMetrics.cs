using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class PersonMetrics
    {
        public int Age { get; set; }
        public String Sex { get; set; } 
        public double Weight_lbs { get; set; }
        public int Height_cm { get; set; }
        public int ActivityLevel { get; set; } // arbitrary number(0-1) based on how active the person is

    }
}
