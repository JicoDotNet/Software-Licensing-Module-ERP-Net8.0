using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicensingERP.Logic.Model.Interface;

namespace LicensingERP.Logic.Model.Class
{
    public class ReturnObject : IReturnObject
    {
        public bool Status { get; set; }
        public object ReturnData { get; set; }
        public int ResponseStatus { get; set; }
        public string Message { get; set; }
    }
}
