using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealDataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);

        //Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        //void AddRange();
        Task<int> RemoveAsync(int Id);
    }
}
