using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
   public class ClientCategory : IClientCategory, ISession, IActivity, IIdentity, IStatus
    {
        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }


        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }

    }
}
