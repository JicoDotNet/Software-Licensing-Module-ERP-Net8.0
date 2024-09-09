using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
   public class UserMenu: IUserMenu, ISession, IActivity, IIdentity, IStatus
    {
        public int MenuId { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }

        public string Menu { get; set; }
        public string User { get; set; }
        public string Usertype { get; set;}

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
