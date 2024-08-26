using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class UserTypeUserModel
    {
        public IReadOnlyList<UserType> UserTypes { get; set; }
        public IReadOnlyList<User> Users { get; set; }
        public User user { get; set; }
    }
}
