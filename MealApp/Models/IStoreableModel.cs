using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealApp.Models
{
    // generic conversion function from stored model to the app model
    interface IStoreableModel<AppMod, DbMod> 
        where AppMod : class 
        where DbMod : class
    {
        public AppMod readDBEquivalent(DbMod dbMod);
    }
}
