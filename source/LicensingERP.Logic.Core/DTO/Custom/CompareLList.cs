using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
   public class CompareLList
    {
        public LicenceCompare licenceCompare { get; set; }
        public List<RequestRestrict> requestRestricts { get; set; }
        public List<RequestParameter> requestParameters { get; set; }
        public List<RequestFeature> requestFeatures { get; set; }
        public RequisitionClaim requisitionClaim { get; set; }
    }
}
