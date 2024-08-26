using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.ReportClass
{
    public class ReportOfUser : IUser,IUserType
    {
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        public bool? IsActive { get; set; }
    }
}
