using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Repositories
{
    public interface ISimulationRepository : IRepository<SimulationProjectModel>
    {
        Task<IEnumerable<SimulationProjectModel>> GetAllAsync();
        Task<int> AddAsync(int Id,
                    string simName,
                    string simDesc,
                    string gitURL,
                    int dimensions);
    }
}
