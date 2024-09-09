using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///    tbl_product
    /// </summary>
    public interface IProduct
    {   
        //string LicenceTypeId { get; set; }
        string ProductName { get; set; }
        string ProductDetails { get; set; }
        IList<IProductFeatures> Features { get; set; }
        IList<IProductModule> Module { get; set; }
    }
}
