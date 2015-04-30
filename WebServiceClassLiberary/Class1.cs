using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;

namespace WebServiceClassLiberary
{
    public class Class1
    {
        public XDocument getList(string franchUserID, string password, int userID, string userKey, string username, string userrole, string userstatus, int usertype)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetPlaceList";
            int PlaceID = 0;
            string placeCode = "";
            string placeName = "";
            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = "com.busindia.webservices";
                XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                        new XElement("franchUserID", franchUserID),
                        new XElement("password", password),
                        new XElement("userID", userID),
                        new XElement("userKey", userKey),
                        new XElement("userName", username),
                        new XElement("userRole", userrole),
                        new XElement("userStatus", userstatus),
                        new XElement("userType", usertype)
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getservice(string franchUserID, string password, int userID, string userKey, string username, string userrole, string userstatus, 
            int usertype, string fromplaceID, string fromplaceCode, string fromplaceName,
            string toplaceID, string toplaceCode, string toplaceName, string journeyDate)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetAvailableServices";
            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = "com.busindia.webservices";
                XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                        new XElement("biFromPlace",
                            new XElement("placeCode", fromplaceCode),
                            new XElement("placeID", fromplaceID),
                            new XElement("placeName", fromplaceName)
                            ),
                        new XElement("biToPlace",
                            new XElement("placeCode", toplaceCode),
                            new XElement("placeID", toplaceID),
                            new XElement("placeName", toplaceName)
                            ),
                        new XElement("journeyDate", journeyDate),
                        new XElement("wsUser",
                            new XElement("franchUserID", franchUserID),
                            new XElement("password", password),
                            new XElement("userID", userID),
                            new XElement("userKey", userKey),
                            new XElement("userName", username),
                            new XElement("userRole", userrole),
                            new XElement("userStatus", userstatus),
                            new XElement("userType", usertype)
                        )
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }
    }
}
