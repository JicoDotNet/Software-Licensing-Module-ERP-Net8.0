using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.SP
{
    public class StoreProcedure
    {
        public static string LoginAuthenticate { get { return "Sp_Login"; } }
        public static string GetMaster { get { return "sp_Get_Master"; } }

        public static string SetProduct { get { return "sp_Set_product"; } }
        public static string SetProductFeatures { get { return "sp_Set_product_features"; } }
        public static string SetProductModule { get { return "sp_Set_product_module"; } }
        public static string SetMenuForUser { get { return "sp_Set_usermenu"; } }
        public static string SetUser { get { return "sp_Set_user"; } }
        public static string SetePasswordSecurityQuestions { get { return "sp_Set_password_security_questions"; } }
        public static string SetPasswordResetRequest { get { return "sp_Set_password_Reset_Request"; } }
        public static string SetPassword { get { return "sp_Set_password"; } }
        public static string SetUserType { get { return "sp_Set_usertype"; } }
        public static string SetClient { get { return "sp_Set_client"; } }
        public static string SetLicenceType { get { return "sp_Set_license_type"; } }
        public static string SetWFProcess { get { return "sp_Set_wf_process"; } }
        public static string SetWFProcessAssign { get { return "sp_Set_wf_process_assign"; } }
        public static string SetParameters { get { return "sp_Set_parameters"; } }
        public static string SetClientCategory { get { return "sp_Set_ClientCategory"; } }
        public static string SetLicenceParameter { get { return "sp_Set_license_parameters"; } }
        public static string SetRequest { get { return "sp_Set_request"; } }
        public static string SetRequestRestrict { get { return "sp_Set_request_restrict"; } }
        public static string SetRequestClaim { get { return "sp_Set_request_claim"; } }
        public static string SetRequestAcknowledgement { get { return "sp_Set_request_acknowledgement"; } }
        public static string SetRequestParameter { get { return "sp_Set_request_parameter"; } }
        public static string SetRequestFeatures { get { return  "sp_Set_request_features"; } } 

        //System 
        public static string GetWfState { get { return "sp_Get_WF_State"; } }

        //Xml
        public static string GetXml { get { return "sp_Get_Xml"; } }


        // Menu/Dashboard Permission
        public static string GetMenuForUser { get { return "sp_Get_usermenu"; } }
        public static string GetDashboardForUser { get { return "sp_Get_userdashboard"; } }


        public static string GetProduct { get { return "sp_Get_product"; } }
        public static string GetProductFeatures { get { return "sp_Get_product_features"; } }
        public static string GetProductModule { get { return "sp_Get_product_module"; } }        
        public static string GetMenuForAssign { get { return "sp_get_menu_list"; } }
        public static string GetUser { get { return "sp_Get_user"; } }
        public static string GetePasswordSecurityQuestions { get { return "sp_Get_password_security_questions"; } }
        public static string GetPasswordResetRequest { get { return "sp_Get_password_Reset_Request"; } }
        public static string GetUserType { get { return "sp_Get_usertype"; } }
        public static string GetClient { get { return "sp_Get_client"; } }
        public static string GetClientCategory { get { return "sp_Get_ClientCategory"; } }
        public static string GetLicenceType { get { return "sp_Get_licence_type"; } }
        public static string GetWFProcess { get { return "sp_Get_wf_process"; } }
        public static string GetRequestAcknowledgement { get { return "sp_Get_request_acknowledgement"; } }
        public static string GetWFProcessAssign { get { return "sp_Get_wf_process_assign"; } }
        public static string GetParameter { get { return "sp_Get_parameter"; } }
        public static string GetLicenceofParameter { get { return "sp_Get_license_parameters"; } }
        public static string GetRequest { get { return "sp_Get_request"; } }

        /*-- Report Store Procedure List-- */
        /// <summary>
        /// Store Procedure of All Reports
        /// </summary>
        public static string RpUserList { get { return "sp_Rp_user"; } }
        public static string RpRequestList { get { return "sp_Rp_Request"; } }
        public static string RpUserLoginList { get { return "sp_Rp_UserLogin"; } }
        public static string RpActivityList { get { return "sp_Rp_Activity"; } }
        public static string RpRequestMovementList { get { return "sp_Rp_RequestMovement"; } }
        public static string RpMakerCheckerList { get { return "sp_Rp_MakerChecker"; } }
        public static string RpTurnAroundTime { get { return "sp_Rp_TAT_License_Generation"; } }
        public static string RpStatus { get { return "sp_Rp_Status"; } }
        public static string RpRequestOnHold{ get { return "sp_Rp_RequestOnHold"; } }
        public static string RpXmlDownload { get { return "sp_Rp_XmlDownload"; } }
        public static string RpRequestPendingList { get { return "sp_Rp_RequestPending"; } }


        /* -- Maker Chaker -- */
        public static string SetMCDataOnHold { get { return "sp_Set_mc_DataOnHold"; } }
        public static string GetMCDataOnHold { get { return "sp_Get_mc_DataOnHold"; } }


        /* -- Dashboard -- */
        public static string GetDashboard { get { return "sp_Get_DashboardData"; } }
        public static string SetUserDashBoard { get { return "sp_Set_userdashboard";  } }


        public static string GetlicenceCompare { get { return "sp_Get_Compare"; } }

        /* -- Licence Alert -- */
        //public static string GetLicenceExpiry { get { return "sp_Get_LicenceExpiry"; } }



        public static string GetUserMailList { get { return "sp_Get_Mail_UserType"; } }

        public static string GetFollowUpList { get { return "sp_Get_FollowUp"; } }
        public static string SetFollowUp{ get { return "sp_Set_FollowUp"; } }

        public static string AdminRequisitionList { get { return "Sp_get_Admin_RequisitionList"; } }


        public static string ClaimbyAdmin { get { return "sp_set_AdminClaim"; } }
    }

}
