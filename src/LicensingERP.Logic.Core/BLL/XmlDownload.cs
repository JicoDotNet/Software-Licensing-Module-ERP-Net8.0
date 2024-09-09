using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;
using System.IO;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlTypes;

namespace LicensingERP.Logic.BLL
{
    public class XmlDownload : ConnectionString
    {
        public XmlDownload(sCommonDto CommonObj) : base(CommonObj) { }

        public MemoryStream GetDownloadData(int UserId, int UserTypeId, int RequestId, int id2, out string RequestNo)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId", RequestId),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "XML")
            };
            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetXml, NameValuePairs);
            RequisitionRequest request = dataSet.Tables[0].ToList<RequisitionRequest>().FirstOrDefault();
            request.RequestParameters = dataSet.Tables[1].ToList<RequestParameter>();
            request.RequestRestricts = dataSet.Tables[2].ToList<RequestRestrict>();
            request.RequestFeatures = dataSet.Tables[3].ToList<RequestFeature>();

            RequestNo = request.RequestNo;
            return GetLicenseXML(request, id2);
        }

        private MemoryStream GetLicenseXML(RequisitionRequest request, int id2)
        {
            List<XElement> FeatureXElements = new List<XElement>();
            for (int i = 0; i < request.RequestFeatures.Count; i++)
            {
                FeatureXElements.Add(new XElement("Features_" + (i + 1).ToString(), request.RequestFeatures[i].FeaturesName));
            }
            List<XElement> ParamXElements = new List<XElement>();
            for (int j = 0; j < request.RequestParameters.Count; j++)
            {
                ParamXElements.Add(new XElement(request.RequestParameters[j].FieldName, request.RequestParameters[j].ParamValue));
            }

            List<XElement> RestrictXElements = new List<XElement>();
            for (int j = 0; j < request.RequestRestricts.Count; j++)
            {
                RestrictXElements.Add(new XElement(request.RequestRestricts[j].RestrictTo.Replace(" ", "_"), request.RequestRestricts[j].RestrictVal));
            }

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false
            };
            
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    XDocument xmlDocument = new XDocument(
                         new XElement("xml",
                            new XElement("LICENSETYPE", request.TypeName),
                            new XElement("PRODUCT", request.ProductName),
                            new XElement("CLIENT", request.ClientName),
                            new XElement("LICENSE_NUMBER", ++id2),
                            new XElement("RESTRICT", RestrictXElements),
                            new XElement("PARAM", ParamXElements),
                            new XElement("FEATURES", FeatureXElements)
                         )
                    );
                    xmlDocument.WriteTo(xmlWriter);
                    xmlWriter.Flush();

                    string xmlString = stringWriter.ToString();
                    return EncryptToBase64(xmlString);
                }
            }
        }

        private MemoryStream EncryptToBase64(string xmlString)
        {
            MemoryStream memoryStream = new MemoryStream();
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
            string base64String = Convert.ToBase64String(xmlBytes);

            StreamWriter writer = new StreamWriter(memoryStream);
            writer.Write(base64String);
            writer.Flush();
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}
