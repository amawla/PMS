using DAL.Repositories;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICategoryRepository _categories;
        IAttributesRepository _attributes;
        IProductsRepository _products;
        IProductDetailsRepository _productDetails;
        IProductImagesRepository _productImages;
        IProductAttributesRepository _productAttributes;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_context);
                }
                return _categories;
            }

        }

        public IAttributesRepository Attributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new AttributesRepository(_context);
                }
                return _attributes;
            }

        }

        public IProductsRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductsRepository(_context);
                }
                return _products;
            }

        }

        public IProductDetailsRepository ProductDetails
        {
            get
            {
                if (_productDetails == null)
                {
                    _productDetails = new ProductDetailsRepository(_context);
                }
                return _productDetails;
            }

        }

        public IProductImagesRepository ProductImages
        {
            get
            {
                if (_productImages == null)
                {
                    _productImages = new ProductImagesRepository(_context);
                }
                return _productImages;
            }

        }

        public IProductAttributesRepository ProductAttributes
        {
            get
            {
                if (_productAttributes == null)
                {
                    _productAttributes = new ProductAttributesRepository(_context);
                }
                return _productAttributes;
            }

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
