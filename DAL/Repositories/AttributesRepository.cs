using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class AttributesRepository : Repository<AttributesModel>, IAttributesRepository
    {
        public AttributesRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public IEnumerable<AttributesGridViewModel> GetAllAttributes()
        {
            List<AttributesGridViewModel> allAttributes = new List<AttributesGridViewModel>();
            allAttributes = (from attributes in _appContext.Attributes
                             select new AttributesGridViewModel
                             {
                                 Attribute_Id = attributes.Attribute_Id,
                                 Attribiute_Name = attributes.Attribiute_Name,
                                 Status = attributes.Active,
                                 Creation_Date = attributes.Creation_Date

                             }).ToList();
            return allAttributes;
        }
    }
}
