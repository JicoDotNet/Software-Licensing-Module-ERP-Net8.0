using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.ReportClass
{
    public class ReportOfUserLogin : ISession, IActivity, ILoginUserName, IDateParameter
    {
        public string SessionId { get; set;}

        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }

        public string UserName { get; set; }

        public int? FromDay { get; set; }
        public int? FromMonth { get; set; }
        public int? FromYear { get; set; }

        public int? ToDay { get; set; }
        public int? ToMonth { get; set; }
        public int? ToYear { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string FromDateFormat { get; private set; }
        public string ToDateFormat { get; private set; }

        public string DateFormat { get { return "%m-%d-%Y"; } }

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

