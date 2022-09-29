using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface  IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IAttributesRepository Attributes { get; }
        IProductsRepository Products { get; }
        IProductDetailsRepository ProductDetails { get; }
        IProductImagesRepository ProductImages { get; }
        IProductAttributesRepository ProductAttributes { get; }

        int SaveChanges();
    }
}
