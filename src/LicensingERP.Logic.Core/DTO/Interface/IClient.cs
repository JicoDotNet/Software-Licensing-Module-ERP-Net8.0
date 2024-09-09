using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{

    /// <summary>
    /// tbl_client
    /// </summary>
    public interface IClient
    {
        int CategoryId { get; set; }
        string ClientName { get; set; }
        string ClientNumber { get; set; }
        string ClientEmail { get; set; }
        string CompanyName { get; set; }
        string CompanyAddress { get; set; }
        string CompanyNumber { get; set; }
        string CompanyEmail { get; set; }
        string GSTIN { get; set; }
        string PANNo { get; set; }



    }
}
