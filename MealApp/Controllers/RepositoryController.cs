using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDataAccess.Repositories;

namespace MealApp.Controllers
{
    public class RepositoryController : Controller
    {
        private UnitOfWork UnitOfWork;

        public RepositoryController(UnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
