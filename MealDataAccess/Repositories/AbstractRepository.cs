using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MealDataAccess.Repositories
{
    internal abstract class AbstractRepository
    {
        protected IDbTransaction _transaction { get; private set; }
        protected IDbConnection _connection
        {
            get { return _transaction.Connection; }
        }

        protected string _type { get; set; }  // used in the generic repo functions to build sql statements 

        public AbstractRepository(IDbTransaction dbTransaction)
        {
            _transaction = dbTransaction;
        }
    }
}
