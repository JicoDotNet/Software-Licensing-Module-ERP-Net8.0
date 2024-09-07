using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IRequestRestrictMeta
    {
        int? Id { get; set; }
        string Name { get; set; }   // - RestrictTo
        bool IsActive { get; set; }
    }

    
}
