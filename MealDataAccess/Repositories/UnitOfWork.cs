﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace MealDataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        private bool _disposed;

        // all availible repos
        private IRecipeRepository _RecipeRepo;
        private IIngredientRepository _IngredientRepo;
        private INutritionRepository _NutritionRepo;

        public UnitOfWork(string cnnString)
        {
            _dbConnection = new SQLiteConnection(cnnString);
            _dbConnection.Open();
            _dbTransaction = _dbConnection.BeginTransaction();
            _disposed = false;
        }

        public IRecipeRepository RecipeRepo
        {
            get { return _RecipeRepo ?? (_RecipeRepo = new RecipeRepository(_dbTransaction)); }
        }

        public IIngredientRepository IngredientRepo
        {
            get { return _IngredientRepo ?? (_IngredientRepo = new IngredientRepository(_dbTransaction)); }
        }

        public INutritionRepository NutritionRepo
        {
            get { return _NutritionRepo ?? (_NutritionRepo = new NutritionRepository(_dbTransaction)); }
        }

        public void Save()
        {
            try
            {
                // when changes are made try to commit the changes to the repository
                _dbTransaction.Commit();
            }
            catch
            {
                // if there are any errors in changes, delete them and revert to previous version of db
                _dbTransaction.Rollback();
                throw;
            }
            finally
            {
                // once the above two steps are finished dispose of the current repos and prepare for any next requests
                _dbTransaction.Dispose();
                _dbTransaction = _dbConnection.BeginTransaction();
                _RecipeRepo = null;
            }
        }

        public void Dispose()
        {
            // when called to dispose call the dsiposeHelper to delete the repository
            // then request that during object cleanup later that the destructor not be called(it has already been deleted)
            DisposeHelper(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            // destructor helper function
            DisposeHelper(false);
        }

        private void DisposeHelper(bool toBeDisposed)
        {
            // this function helps in the destruction of the current repo 
            if (!_disposed)
            {
                if (toBeDisposed)
                {
                    if (_dbTransaction != null)
                    {
                        _dbTransaction.Dispose();
                        _dbTransaction = null;
                    }
                    if (_dbConnection != null)
                    {
                        _dbConnection.Dispose();
                        _dbConnection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
