using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class RequestParameter : IRequestParameter, IParameter, ISession, IActivity, IIdentity, IStatus
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public int ParamId { get; set; }
        public string ParamValue { get; set; }

        public string FieldName { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public string Fieldlength { get; set; }
        public string ListData { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }


    }
}
