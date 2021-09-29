using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class Group
    {
        public List<Person> GroupMembers { get; set; }
        public Calender GroupPlan { get; set; }


    }
}
