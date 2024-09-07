using LicensingERP.Logic.DTO.Interface;
using Org.BouncyCastle.Asn1.Cms;
using System;

namespace LicensingERP.Logic.Model.Class
{
    public class AuthticateCredential : IUserIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int UserTypeId { get; set; }
       public string Email { get; set; }
    }
}
