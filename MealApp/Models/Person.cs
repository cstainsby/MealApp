using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MealApp.Models
{
    public class Person : IdentityUser<int>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public PersonMetrics Metrics { get; set; }
        public List<Recipe> CreatedRecipes { get; set; }
        public List<Recipe> SavedRecipes { get; set; }
    }
}
