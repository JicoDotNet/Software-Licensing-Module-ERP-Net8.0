using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class RequestRestrictMeta : IRequestRestrictMeta
    {
        public int? Id { get; set; }
        public string Name { get; set; }    // - RestrictTo
        public bool IsActive { get; set; }
    }
    public class RequestRestrictsMeta : List<RequestRestrictMeta> { }
}
