using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class ProductFeaturesModule
    {
        public IReadOnlyList<Product> Products { get; set; }
        public IReadOnlyList<LicenceType> LicenceTypes { get; set; }
        public IReadOnlyList<ProductFeatures> Features { get; set; }
        public IReadOnlyList<ProductModule> Modules { get; set; }
        // arindrajit Implement
        //public IReadOnlyList<RequestType> RequestType { get; set; }
    }
}
