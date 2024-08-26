using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class ParameterOfLicence : IParameterOfLicence, IParameter, ILicenceType, ISession, IActivity, IIdentity, IStatus
    {
        public int ParameterId { get; set; }
        public int LicenseTypeId { get; set; }
        public string FieldName { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public string Fieldlength { get; set; }
        public string ListData { get; set; }
        /// <summary>
        /// tbl_licencetype 
        /// </summary>
        public string TypeName { get; set; }
        public string LicenceTypeDetails { get; set; }
        public int NumberOfLicence { get; set; }
        public bool IsScalingEligible { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
