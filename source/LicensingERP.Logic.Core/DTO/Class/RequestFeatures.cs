using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class RequestFeature : IRequestFeature,IProductFeatures,ISession, IActivity, IIdentity, IStatus
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public int FeaturesId { get; set; }
        public int ProductId { get; set; }


        public string FeaturesName { get; set; }
        public string FeaturesDetails { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
