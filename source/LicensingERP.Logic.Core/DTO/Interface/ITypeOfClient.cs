using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///  tbl_client_type
    /// </summary>
    public interface ITypeOfClient
    {
         string ClientType { get; set; }
         string Detalis { get; set; }

    }
}
