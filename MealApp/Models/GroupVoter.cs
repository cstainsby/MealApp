using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    public class GroupVoter
    {
        public Recipe Recipe { get; set; }
        public List<Person> ForMeal { get; set; }
        public List<Person> AgainstMeal { get; set; }

        private String SuggestedTime;
        
        /*public Tuple<int,int,int> getSuggestedTime()
        {
            // read String SuggestedTime that is stored in text into a tuple of int's
            Tuple<int, int, int> time = new Tuple<int, int, int>
                (
                    this.SuggestedTime
                );

            return time;
        }*/
    }
}
