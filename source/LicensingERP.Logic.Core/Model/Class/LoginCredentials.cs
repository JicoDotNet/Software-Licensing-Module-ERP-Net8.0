using System;
using LicensingERP.Logic.DTO.Interface;
using LicensingERP.Logic.Model.Interface;

namespace LicensingERP.Logic.Model.Class
{
    public class LoginCredentials : ILogin,
        IUser,
        IUserType,
        IStatus
    {
        public string UserName { get; set; }
        public string PasswordText { get; set; }

        public int UserId { get; set; }
        public bool IsChangeable { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }

        public bool IsActive { get; set; }

        public int BUsertypeId { get; set; }
        public int BUserId { get; set; }
    }
}
