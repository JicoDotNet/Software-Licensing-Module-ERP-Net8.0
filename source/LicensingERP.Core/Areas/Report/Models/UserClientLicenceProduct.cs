using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Areas.Report.Models
{
    public class UserClientLicenceProduct
    {
        public IReadOnlyList<LicenceType> licenceType { get; set; }
        public IReadOnlyList<Client> client { get; set; }
        public IReadOnlyList<Product> product { get; set; }
        public IReadOnlyList<User>  user { get; set; }
    }
}
