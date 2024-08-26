using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _ClientCategory
    {
        public IReadOnlyList<ClientCategory> clientcategories { get; set; }
        public ClientCategory clientcategory { get; set; }
    }
}
