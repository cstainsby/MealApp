using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // add new repositories here
        IMealRepository SimulationRepo { get; }

        // Save will save the database after modifications have been made
        void Save();
    }
}
