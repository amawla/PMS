using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Controllers
{
    public class CategoriesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var model = _unitOfWork.Categories.GetAllCategories();
            return View(model);
        }
    }
}