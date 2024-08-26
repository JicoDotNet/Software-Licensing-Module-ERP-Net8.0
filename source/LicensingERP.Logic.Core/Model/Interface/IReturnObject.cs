using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.Model.Interface
{
    public interface IReturnObject
    {
        bool Status { get; set; }
        object ReturnData { get; set; }
        string Message { get; set; }
        int ResponseStatus { get; set; }
    }
}
