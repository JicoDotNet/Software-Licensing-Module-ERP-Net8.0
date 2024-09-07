using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// tbl_request....
/// </summary>
namespace LicensingERP.Logic.DTO.Class
{
    public class RequisitionRequest : IRequisitionRequest, IUser, IClient, ILicenceType, IProduct, ISession, IActivity, IIdentity, IStatus
    {
        public string UserName { get; set; }


        public int ClientId { get; set; }
        public int LicenceTypeId { get; set; }
        public int ProductId { get; set; }
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string LicenceNo { get; set; }
        /// <summary>
        /// Expiry Date add 
        /// </summary>
        /// 
        
        public int? ExpDay { get; set; }
        public int? ExpMonth { get; set; }
        public int? ExpYear { get; set; }
      

        public DateTime? ExpiryDate { get; set; }
        public string ExpiryDateFormat { get; private set; }
        public string DateFormat { get { return "%m-%d-%Y"; } }

        // public DateTime ExpiryDate { get; set; }

        public bool IsClaimed { get; set; }

        /// <summary>
        /// IUser
        /// </summary>
        //public int UserTypeId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        /// <summary>
        /// IClient
        /// </summary>
        public int CategoryId { get; set; }
        public string ClientType { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public string ClientEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string GSTIN { get; set; }
        public string PANNo { get; set; }

        /// <summary>
        /// ILicenceType
        /// </summary>
        public string TypeName { get; set; }
        public string LicenceTypeDetails { get; set; }
        public int NumberOfLicence { get; set; }
        public bool IsScalingEligible { get; set; }

        /// <summary>
        /// IProduct
        /// </summary>
        public IList<IProductFeatures> Features { get; set; }
        public IList<IProductModule> Module { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }

        public List<RequestParameter> RequestParameters { get; set; }
        public List<RequestRestrict> RequestRestricts { get; set; }
        public List<RequestFeature> RequestFeatures { get; set; }

        public List<ByPassRequisitionClaim> byPassRequisitionClaims { get; set; }

        public ByPassRequisitionClaim byPassRequisition { get; set; }
        // public RequisitionClaim requisitionClaim { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }




        public void ToDateObject()
        {
            try
            {
                this.ExpiryDate = new DateTime(ExpYear.Value, ExpMonth.Value, ExpDay.Value);
                //this.ToDate = new DateTime(ToYear.Value, ToMonth.Value, ToDay.Value);

                this.ExpiryDateFormat = this.ExpiryDate.Value.Month.ToString() + "-" +
                    this.ExpiryDate.Value.Day.ToString() + "-" +
                     this.ExpiryDate.Value.Year.ToString();

                //this.ToDateFormat = this.ToDate.Value.AddDays(1).Month.ToString() + "-" +
                //    this.ToDate.Value.AddDays(1).Day.ToString() + "-" +
                //     this.ToDate.Value.AddDays(1).Year.ToString();
            }
            catch
            {
                this.ExpiryDate = null;
                //this.ToDate = null;
                this.ExpiryDateFormat = null;
                //this.ToDateFormat = null;
            }
        }
    }
}
