using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.ReportClass
{
    public class ReportOfStatus : RequestStatus, IWfState, IStatus, IDateParameter
    {
        public string Name { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public bool IsInitial { get; set; }
        public bool IsHold { get; set; }


        public int? FromDay { get; set; }
        public int? FromMonth { get; set; }
        public int? FromYear { get; set; }
  
        public int? ToDay { get; set; }
        public int? ToMonth { get; set; }
        public int? ToYear { get; set; }

        public string FromDateFormat { get; set; }
        public string ToDateFormat { get; set; }

        public string DateFormat { get { return "%m-%d-%Y"; } }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public void ToDateObject()
        {
            try
            {
                this.FromDate = new DateTime(FromYear.Value, FromMonth.Value, FromDay.Value);
                this.ToDate = new DateTime(ToYear.Value, ToMonth.Value, ToDay.Value);

                this.FromDateFormat = this.FromDate.Value.Month.ToString() + "-" +
                    this.FromDate.Value.Day.ToString() + "-" +
                     this.FromDate.Value.Year.ToString();

                this.ToDateFormat = this.ToDate.Value.AddDays(1).Month.ToString() + "-" +
                    this.ToDate.Value.AddDays(1).Day.ToString() + "-" +
                     this.ToDate.Value.AddDays(1).Year.ToString();
            }
            catch
            {
                this.FromDate = null;
                this.ToDate = null;
                this.FromDateFormat = null;
                this.ToDateFormat = null;
            }
        }
    }
}
