using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Models;
using static MealDataAccess.Processor; // statically include to use static functions without instantiating object
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace MealDataAccess.Repositories
{
    internal class RecipeRepository : Repository<RecipeModel>, IRecipeRepository
    {
        // possibly add a copy helper
        public RecipeRepository(IDbTransaction _transaction) : base(_transaction)
        {
            _type = "Simulation";
        }

        // retrieve all items of type SimulationModel within the db 
        public async Task<IEnumerable<RecipeModel>> GetAllAsync()
        {
            string sql = @"SELECT Id, simName, simDesc, gitURL FROM dbo." + _type;

            return await _connection.QueryAsync<RecipeModel>
                (sql,
                transaction: _transaction);
        }

        // create a new item of type SimulationModel within db given Id
        public async Task<int> AddAsync()
        {
            RecipeModel entity = processSimulation(
            );

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            string sql = @"INSERT INTO dbo." + _type + " (simName, simDesc, gitURL) VALUES(@simName, @simDesc, @gitURL);";

            sql = sql.Replace("@simName", $"'{entity.simName}'");
            sql = sql.Replace("@simDesc", $"'{entity.simDesc}'");
            sql = sql.Replace("@gitURL", $"'{entity.gitURL}'");

            int rowsAffected = await _connection.ExecuteAsync
                (sql,
                new { Id = entity.Id, simName = entity.simName, gitURL = entity.gitURL, simDesc = entity.simDesc },
                transaction: _transaction);

            return rowsAffected;
        }
    }
}
