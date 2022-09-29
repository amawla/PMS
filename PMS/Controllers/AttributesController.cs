using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Controllers
{
    public class AttributesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public AttributesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var model = _unitOfWork.Attributes.GetAllAttributes();
            return View(model);
        }
    }
}