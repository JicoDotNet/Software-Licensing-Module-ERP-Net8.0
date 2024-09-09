using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Model.Class;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using LicensingERP.Models;
using System.Linq;
using LicensingERP.Logic.Enumeration;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class ProductController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        // GET: Product
        public ActionResult Index()
        {

            ProductLogic productlogic = new ProductLogic(BllCommonLogic);
            _Products _product = new _Products
            {
                Products = productlogic.GetProuct()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _product.product = _product.Products.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(_product);
            
        }

        [HttpPost]
        public ActionResult Index(Product product)
        {
            product.ProductDetails = product.ProductDetails.Trim();
            ProductLogic productLogic = new ProductLogic(BllCommonLogic);
            int flag = 0;
            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                DataOnHold<Product> dataOnHold = new DataOnHold<Product>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eDataOnHoldCaseType.Product,
                    ePurpose = eDataOnHoldPurpose.Insert,
                    tEffectedData = product
                };
                dataOnHold.ToString();
                flag = new DataOnHoldLogic<Product>(BllCommonLogic).Insert(dataOnHold);
                if(flag > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Submitted. Waiting for approval !!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = " Error To Data Submited !!"
                    };
                }
                #endregion
                // productLogic.Insert(product);
            }
            else
            {
                product.Id = Convert.ToInt32(id);
                // productLogic.Update(product);

                #region Maker Checker
                DataOnHold<Product> dataOnHold = new DataOnHold<Product>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eDataOnHoldCaseType.Product,
                    ePurpose = eDataOnHoldPurpose.Update,
                    tEffectedData = product
                };
                dataOnHold.ToString();
                flag = new DataOnHoldLogic<Product>(BllCommonLogic).Insert(dataOnHold);
                if (flag > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Updated Request Submit Successfully !!"
                    };
                }
                else if(flag == 0 )
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "You can't proceed for this data untill previous approval move on !!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Error To  Update !!"
                    };
                }
                #endregion

                
            }

            return RedirectToAction("Index", new { id = string.Empty });
        }
        
        [HttpGet]
        public PartialViewResult FeatureAdd()
        {
            ProductFeatures productFeatures = new ProductFeatures { ProductId = Convert.ToInt32(id) };
            return PartialView("_PartialProductFeaturesAdd", productFeatures);
        }

        [HttpGet]
        public PartialViewResult ModuleAdd()
        {
            UserType userType = new UserType {Id = Convert.ToInt32(id) };
            return PartialView("_PartialProductModuleAdd", userType);
        }

        [HttpGet]
        public PartialViewResult ModuleList()
        {
            ProductModuleLogic productmodulelist = new ProductModuleLogic(BllCommonLogic);
            List<ProductModule> ProductModule = productmodulelist.GetDatas(Convert.ToInt32(id));
            return PartialView("_PartialProductModuleList", ProductModule);
        }

        public PartialViewResult FeaturesList()
        {
            ProductFeaturesLogic productfeature = new ProductFeaturesLogic(BllCommonLogic);
            List<ProductFeatures> ProductFeatures = productfeature.GetDatas(Convert.ToInt32(id));
            return PartialView("_PartialProductFeaturesList", ProductFeatures);            
        }

        [HttpPost]
        public JsonResult Features([FromBody]ProductFeatures productfeatures)
        {
            productfeatures.ProductId = Convert.ToInt32(id);
           // ProductFeaturesLogic productfeatureslogic = new ProductFeaturesLogic(BllCommonLogic);
            #region Maker Checker
            DataOnHold<ProductFeatures> dataOnHold = new DataOnHold<ProductFeatures>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eDataOnHoldCaseType.ProductFeatures,
                ePurpose = eDataOnHoldPurpose.Insert,
                tEffectedData = productfeatures
            };
            dataOnHold.ToString();
            int val = new DataOnHoldLogic<ProductFeatures>(BllCommonLogic).Insert(dataOnHold);
            #endregion

            //  int val = productfeatureslogic.Insert(productfeatures);
            return Json(val);
        }

        [HttpPost]
        public JsonResult Module([FromBody]ProductModule productmodule)
        {
            productmodule.ProductId = Convert.ToInt32(id);
            ProductModuleLogic productmodulelogic = new ProductModuleLogic(BllCommonLogic);
            int val = productmodulelogic.Insert(productmodule);
            return Json(val);
        }

        [HttpGet]
        public PartialViewResult Deactivate()
        {
            Product product = new ProductLogic(BllCommonLogic).GetProductType(Convert.ToInt32(id));
            return PartialView("_PartialProductDeactivate", product);
        }

        [HttpPost]
        public JsonResult Deactivate(string Context)
        {
            LoginCredentials loginCredentials = new LoginCredentials()
            {
                UserName = SessionPerson.UserName,
                PasswordText = Context,
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            loginCredentials = loginManagment.Authenticate(loginCredentials);
            if (loginCredentials != null)
            {
                #region Maker Checker
                DataOnHold<Product> dataOnHold = new DataOnHold<Product>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eDataOnHoldCaseType.Product,
                    ePurpose = eDataOnHoldPurpose.Deactivate,
                    tEffectedData = new ProductLogic(BllCommonLogic).GetProductType(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new DataOnHoldLogic<Product>(BllCommonLogic).Insert(dataOnHold));
                #endregion

                // return Json(new ProductLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
            }
            else
            {
                return Json(-1);
            }
        }

    }
}