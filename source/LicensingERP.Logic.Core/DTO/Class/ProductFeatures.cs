using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class ProductFeatures : Product, IProductFeatures, ISession, IActivity, IIdentity, IStatus
    {
        public int ProductId { get; set; }
        public string FeaturesName { get; set; }
        public string FeaturesDetails { get; set; }
        /*Change on 29-06-2020 for  marker and checker updation its inherited from Product class  */
        //public int Id { get; set; }
        //public DateTime TransactionDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string SessionId { get; set; }
        //public bool IsActive { get; set; }
    }
}
