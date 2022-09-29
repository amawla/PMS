using Model.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryGridViewModel> GetAllCategories();
    }
}
