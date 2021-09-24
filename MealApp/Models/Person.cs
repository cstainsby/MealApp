using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealApp.Models;

namespace MealApp.Models
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public PersonMetrics Metrics { get; set; }
        public List<Recipe> CreatedRecipes { get; set; }
        public List<Recipe> SavedRecipes { get; set; }
    }
}
