using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _LicencetypeClientProduct
    {
        public IReadOnlyList<LicenceType> licenceType { get; set; }
        public IReadOnlyList<Client> client { get; set; }
        public IReadOnlyList<Product> product { get; set; }
        public User users { get; set; }
        public CompareLList compareLList { get; set; }
    }
}
