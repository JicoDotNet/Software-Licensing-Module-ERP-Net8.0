using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class WfProcessAssignLogic : ConnectionString
    {
        public WfProcessAssignLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(WfProcessAssign wfProcessAssign)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_WFProcessId", wfProcessAssign.WFProcessId),
                new NameValuePair("p_StateId", wfProcessAssign.StateId),
                new NameValuePair("p_FromUserTypeId", wfProcessAssign.FromUserTypeId),
                new NameValuePair("p_ToUserTypeId", wfProcessAssign.ToUserTypeId),
                new NameValuePair("p_ActivityStartDate", GenericLogic.IstNow),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetWFProcessAssign, nvp, "Out_Param"));
        }

        public List<WfAssign> GetWfProcessAssigns()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "ALL"),
                new NameValuePair("p_LicenceTypeId", 0)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, NameValuePairs).ToList<WfAssign>();
        }
        public List<WfAssign> GetWfProcessAssigns(int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "FORLICENSE"),
                new NameValuePair("p_LicenceTypeId", LicenceTypeId)
            };
            List<WfAssign> wfAssigns = mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, NameValuePairs).ToList<WfAssign>();
            return wfAssigns;
        }

        public WorkflowDiagram GetWfProcessAssignDiagram(int LicenceTypeId)
        {
            List<WfAssign> wfAssigns = GetWfProcessAssigns(LicenceTypeId);
            WorkflowDiagram diagram = new WorkflowDiagram();
            List<node> nodes = new List<node>
                {
                    new node
                    {
                        key = -1,
                        text = "Start",
                        color = eNodeColors.lightgreen.ToString(),
                        shape = "Circle"
                    },
                    new node
                    {
                        key = 0,
                        text = "End",
                        color = eNodeColors.lightcoral.ToString(),
                        shape = "Circle"
                    }
                };
            List<link> links = new List<link>();

            WfAssign wfAssign = wfAssigns?.FirstOrDefault(a => a.IsInitial);
            if (wfAssign != null)
            {
                links.Add(new link
                {
                    from = -1,
                    to = wfAssign.FromUserTypeId,
                    color = eLinkColors.green.ToString(),
                    text = "Starting"
                });
            }
            foreach (WfAssign item in wfAssigns)
            {
                if (nodes.FirstOrDefault(a => a.key == item.FromUserTypeId) == null)
                {
                    nodes.Add(
                        new node
                        {
                            key = item.FromUserTypeId,
                            text = item.FromUserTypeName,
                            color = eNodeColors.lightblue.ToString(),
                            shape = "Diamond"
                        }
                    );
                }
                if (nodes.FirstOrDefault(a => a.key == item.ToUserTypeId) == null)
                {
                    nodes.Add(
                        new node
                        {
                            key = item.ToUserTypeId,
                            text = item.ToUserTypeName,
                            color = eNodeColors.lightblue.ToString(),
                            shape = "Diamond"
                        }
                    );
                }
                if (item.ToUserTypeId == 0)
                {
                    links.Add(new link
                    {
                        from = item.FromUserTypeId,
                        to = 0,
                        text = "Ending " + (item.IsPositive ? "[Approved]" : item.IsNegative ? "[Rejected]" : "[Unknown]"),
                        color = item.IsPositive ? eLinkColors.green.ToString() : item.IsNegative ? eLinkColors.red.ToString() : "yellow",
                    });
                }
                else
                {
                    links.Add(new link
                    {
                        from = item.FromUserTypeId,
                        to = item.ToUserTypeId,
                        text = item.ProcessName + " [" + item.Name + "]",
                        color = (item.IsPositive && !item.IsHold) ? eLinkColors.green.ToString() : (item.IsNegative && !item.IsHold) ? eLinkColors.red.ToString() : (item.IsNegative && item.IsHold) ? eLinkColors.blue.ToString() : "yellow",
                    });
                }
            }
            diagram.nodes = nodes.ToArray();
            if (diagram.nodes.Length > 0)
            {
                links.Add(new link
                {
                    color = eLinkColors.blue.ToString(),
                    from = -1,
                    to = 0,
                    text = "[No Workflow Defined]"
                });
            }
            diagram.links = links.ToArray();

            return diagram;
        }
    }
}
