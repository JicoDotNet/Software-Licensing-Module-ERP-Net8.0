using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IActivity
    {
        DateTime TransactionDate { get; set; }
        string CreatedBy { get; set; }
    }
}
