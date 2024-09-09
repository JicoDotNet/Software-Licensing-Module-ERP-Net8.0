using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{

    /// <summary>
    ///   tbl_licence_type
    /// </summary>
    public interface ILicenceType
    {

        string TypeName { get; set; }
        string LicenceTypeDetails { get; set; }

        /*Change on 29-06-2020 for... */
        //int NumberOfLicence { get; set; }
        //bool IsScalingEligible { get; set; }
    }
}
