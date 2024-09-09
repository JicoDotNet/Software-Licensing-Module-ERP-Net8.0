using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class Product : IProduct, ISession, IActivity, IIdentity, IStatus
    {
        //public string LicenceTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public IList<IProductFeatures> Features { get; set; }
        public IList<IProductModule> Module { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
