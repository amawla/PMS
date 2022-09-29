using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Products;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;

namespace PMS.Controllers
{
    public class ProductsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index(string status="", string message = "")
        {
            ViewBag.Status = status;
            ViewBag.Message = message;
            var products = _unitOfWork.Products.GetAllProducts();
            return View(products);
        }
        public IActionResult ProductDetails(string productId="")
        {

            ProductsViewModel productsViewModel = null;
            if (!string.IsNullOrEmpty(productId))
            {
                productsViewModel = new ProductsViewModel
                {
                    Product = _unitOfWork.Products.GetProductById(new Guid(productId)),
                    ProductDetails = _unitOfWork.ProductDetails.GetProductDetailsByProductId(new Guid(productId)),
                    CategoriesList = _unitOfWork.Categories.GetAllCategories().ToList()
                };
            }
            else
            {
                productsViewModel = new ProductsViewModel
                {
                  
                    CategoriesList = _unitOfWork.Categories.GetAllCategories().ToList(),
                    Attributes = _unitOfWork.Attributes.GetAllAttributes().ToList()
                };
            }
            
            return View(productsViewModel);
        }

        [HttpGet]
        public IActionResult ViewProduct(string productId = "")
        {
            ProductsViewModel model = new ProductsViewModel();
            if (!string.IsNullOrEmpty(productId))
            {
                model.Product = _unitOfWork.Products.GetProductById(new Guid(productId));
                model.ProductDetails = _unitOfWork.ProductDetails.GetProductDetailsByProductId(new Guid(productId));
                model.ProductAttributes = _unitOfWork.ProductAttributes.GetAllProductAttributesByProductId(new Guid(productId)).ToList();
                model.ProductImages = _unitOfWork.ProductImages.GetAllProductImagesByProductId(new Guid(productId)).ToList();
            }
          
            return PartialView("~/Views/Products/ProductDetailsView.cshtml", model);

        }

        [HttpPost]
        public IActionResult AddProduct(string productModel = "")
        {
            string saveMessage = "";
            string productId = "";
            if (!string.IsNullOrEmpty(productModel))
            {
                var deserializedProduct = JsonConvert.DeserializeObject<ProductsViewModel>(productModel);
                try
                {
                    var savedProduct = new ProductsModel
                    {
                        Category_Id = deserializedProduct.Product.Category_Id,
                        Product_Id = Guid.NewGuid(),
                        Product_Name = deserializedProduct.Product.Product_Name,
                        Product_Description = deserializedProduct.Product.Product_Description,
                        Active = true,
                        Creation_Date = DateTime.Now,
                        Modification_Date = DateTime.Now
                    };
                    _unitOfWork.Products.CreateProduct(savedProduct);
                    var saveProductDetails = new ProductDetailsModel
                    {
                        Product_Id = savedProduct.Product_Id,
                        Product_Details_Id = Guid.NewGuid(),
                        Qty_In_Stock = deserializedProduct.ProductDetails.Qty_In_Stock,
                        Tax = deserializedProduct.ProductDetails.Tax,
                        Price = deserializedProduct.ProductDetails.Price,
                        Discount = deserializedProduct.ProductDetails.Discount,
                        Active_Date_From = deserializedProduct.ProductDetails.Active_Date_From,
                        Active_Date_To = deserializedProduct.ProductDetails.Active_Date_To,
                        Active = true,
                        Creation_Date = DateTime.Now,
                        Modification_Date = DateTime.Now
                    };
                    _unitOfWork.ProductDetails.CreateProductDetail(saveProductDetails);
                    var savedProductAttributes = new ProductAttributesModel
                    {
                        Product_Attributes_Id = Guid.NewGuid(),
                        Product_Id = savedProduct.Product_Id,
                        Attribute_Id = new Guid(deserializedProduct.AttributeId),
                        Values = JsonConvert.SerializeObject(deserializedProduct.AttributeValues),
                        Active = true,
                        Creation_Date = DateTime.Now,
                        Modification_Date = DateTime.Now

                    };
                    _unitOfWork.ProductAttributes.CreateProductAttributes(savedProductAttributes);
                    productId = savedProduct.Product_Id.ToString();
                    
                    saveMessage = "Product Save Successfully";
                }
                catch (Exception ex)
                {
                    saveMessage = ex.Message.ToString();
                    return Json(new { Status = "error", Message = saveMessage });
                }
                return Json(new { Status = "success", Message = saveMessage, ProductId= productId });
            }
            else
            {
                saveMessage = "No Data Passed!";
                return Json(new { Status = "error", Message = saveMessage });
            }
        }
     
        [HttpPost]
        public IActionResult UploadProductsImages(IList<IFormFile> files, string productId= "")
        {
            string saveMessage = "";
            List<ProductImagesModel> imagesList = new List<ProductImagesModel>();
            if(files.Count > 0)
            {
                try
                {
                    foreach (IFormFile source in files)
                    {
                        string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        var fileExtension = filename.Split(".").Length > 0 ? filename.Split(".")[filename.Split(".").Length - 1]:"";
                        string fileNameTobeSaved = filename.Split(".").Length > 0 ? filename.Split(".")[0]  + "_" + Guid.NewGuid() +"."+ fileExtension : "";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Images", "Products", fileNameTobeSaved);
                        using (FileStream output = System.IO.File.Create(path))
                        {
                            source.CopyTo(output);
                        }

                        var savedProductImages = new ProductImagesModel
                        {
                            Product_Id = new Guid(productId),
                            Product_Images_Id = Guid.NewGuid(),
                            Image_Path = fileNameTobeSaved,
                            Active = true,
                            Creation_Date = DateTime.Now,
                            Modification_Date = DateTime.Now
                        };
                        imagesList.Add(savedProductImages);
                        
                    }
                    _unitOfWork.ProductImages.CreateProductImages(imagesList);
                    saveMessage = "Product saved successfully and images have been uploaded";
                }
                catch(Exception ex)
                {
                    saveMessage = ex.Message.ToString();
                    return Json(new { Status = "error", Message = saveMessage });
                }
               
                return Json(new { Status = "success", Message = saveMessage, ProductId = productId });
            }
            else
            {
                return Json(new { Status = "error", Message = saveMessage });
            }
        }

        [HttpPost]
        public IActionResult EditProduct(string productModel = "")
        {
            string saveMessage = "";
            string productId = "";
            if (!string.IsNullOrEmpty(productModel))
            {
                var deserializedProduct = JsonConvert.DeserializeObject<ProductsViewModel>(productModel);
                try
                {
                    if (deserializedProduct.Product.Product_Id != null && deserializedProduct.Product.Product_Id != Guid.Empty)
                    {
                        var getProductById = _unitOfWork.Products.GetProductById(deserializedProduct.Product.Product_Id);
                        var getProductDetailsByProductId = _unitOfWork.ProductDetails.GetProductDetailsByProductId(deserializedProduct.Product.Product_Id);

                        if(getProductById != null)
                        {
                            getProductById.Category_Id = getProductById.Category_Id != deserializedProduct.Product.Category_Id ? deserializedProduct.Product.Category_Id
                                    : getProductById.Category_Id;
                            getProductById.Product_Name = getProductById.Product_Name != deserializedProduct.Product.Product_Name ? deserializedProduct.Product.Product_Name
                                : getProductById.Product_Name;
                            getProductById.Product_Description = getProductById.Product_Description != deserializedProduct.Product.Product_Description ? deserializedProduct.Product.Product_Description
                              : getProductById.Product_Description;
                            _unitOfWork.Products.UpdateProduct(getProductById);

                            if (getProductDetailsByProductId != null)
                            {
                                getProductDetailsByProductId.Qty_In_Stock = getProductDetailsByProductId.Qty_In_Stock != deserializedProduct.ProductDetails.Qty_In_Stock ? deserializedProduct.ProductDetails.Qty_In_Stock
                                     : getProductDetailsByProductId.Qty_In_Stock;
                                getProductDetailsByProductId.Tax = getProductDetailsByProductId.Tax != deserializedProduct.ProductDetails.Tax ? deserializedProduct.ProductDetails.Tax
                                     : getProductDetailsByProductId.Tax;
                                getProductDetailsByProductId.Price = getProductDetailsByProductId.Price != deserializedProduct.ProductDetails.Price ? deserializedProduct.ProductDetails.Price
                                     : getProductDetailsByProductId.Price;
                                getProductDetailsByProductId.Discount = getProductDetailsByProductId.Discount != deserializedProduct.ProductDetails.Discount ? deserializedProduct.ProductDetails.Discount
                                     : getProductDetailsByProductId.Discount;
                                getProductDetailsByProductId.Active_Date_From = getProductDetailsByProductId.Active_Date_From != deserializedProduct.ProductDetails.Active_Date_From ? deserializedProduct.ProductDetails.Active_Date_From
                                     : getProductDetailsByProductId.Active_Date_From;
                                getProductDetailsByProductId.Active_Date_To = getProductDetailsByProductId.Active_Date_To != deserializedProduct.ProductDetails.Active_Date_To ? deserializedProduct.ProductDetails.Active_Date_To
                                     : getProductDetailsByProductId.Active_Date_To;

                                _unitOfWork.ProductDetails.UpdateProductDetail(getProductDetailsByProductId);
                            }
                            else
                            {
                                saveMessage = "Product not Found!";
                                return Json(new { Status = "error", Message = saveMessage });
                            }
                        }
                        else
                        {
                            saveMessage = "Product not Found!";
                            return Json(new { Status = "error", Message = saveMessage });
                        }
                        productId = getProductById.Product_Id.ToString();
                        saveMessage = "Product Save Successfully";
                    }
                    else
                    {
                        saveMessage = "Product not Found!";
                        return Json(new { Status = "error", Message = saveMessage });
                    }
                }
                catch (Exception ex)
                {
                    saveMessage = ex.Message.ToString();
                    return Json(new { Status = "error", Message = saveMessage });
                }
                return Json(new { Status = "success", Message = saveMessage, ProductId = productId });
            }
            else
            {
                saveMessage = "No Data Passed!";
                return Json(new { Status = "error", Message = saveMessage });
            }



        }

        [HttpPost]
        public IActionResult DeleteProduct(string productId = "")
        {
            string saveMessage = "";
           
            if (!string.IsNullOrEmpty(productId))
            {
                
                try
                {
                    var productById = _unitOfWork.Products.GetProductById(new Guid(productId));
                    if(productId != null)
                    {
                        _unitOfWork.Products.DeleteProduct(productById);
                        saveMessage = "Removed Successfully";
                    }
                    else
                    {
                        saveMessage = "Product not Found";
                        return Json(new { Status = "error", Message = saveMessage });
                    }
                }
                catch (Exception ex)
                {
                    saveMessage = ex.Message.ToString();
                    return Json(new { Status = "error", Message = saveMessage });
                }
                return Json(new { Status = "success", Message = saveMessage, ProductId = productId });
            }
            else
            {
                saveMessage = "No Data Passed!";
                return Json(new { Status = "error", Message = saveMessage });
            }



        }

      
    }
}