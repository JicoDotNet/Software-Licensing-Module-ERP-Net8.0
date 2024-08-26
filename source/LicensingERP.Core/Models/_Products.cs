using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _Products
    {
        public IReadOnlyList<Product> Products { get; set; }
        public Product product { get; set; }
    }
}
