using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IDateParameter
    {
        int? FromDay { get; set; }
        int? FromMonth { get; set; }
        int? FromYear { get; set; }

        int? ToDay { get; set; }
        int? ToMonth { get; set; }
        int? ToYear { get; set; }

        string FromDateFormat { get; }
        string ToDateFormat { get; }

        string DateFormat { get; }

        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }

        void ToDateObject();
    }
}
