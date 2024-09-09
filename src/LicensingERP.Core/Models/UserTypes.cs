using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _UserTypes
    {
        public IReadOnlyList<UserType> UserTypes { get; set; }
        public UserType UserType { get; set; }
    }
}
