using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public IEnumerable<CategoryGridViewModel> GetAllCategories()
        {
            List<CategoryGridViewModel> allCategories = new List<CategoryGridViewModel>();
            allCategories = (from categories in _appContext.Category
                             select new CategoryGridViewModel
                             {
                                 Category_Id = categories.Category_Id,
                                 Category_Name = categories.Category_Name,
                                 Status = categories.Active,
                                 Creation_Date = categories.Creation_Date,
                                 Products = _appContext.Products.Where(x => x.Category_Id == categories.Category_Id).ToList()

                           }).ToList();
            return allCategories;
        }
    }
}
