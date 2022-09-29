using Model.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IAttributesRepository
    {
        IEnumerable<AttributesGridViewModel> GetAllAttributes();
    }
}
