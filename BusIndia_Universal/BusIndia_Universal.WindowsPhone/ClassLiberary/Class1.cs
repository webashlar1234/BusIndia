using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Web.Http;

namespace BusIndia_Universal.ClassLiberary
{
    class Class1
    {
        public async void postXMLData1()
        {
            string uri = "http://111.93.131.112/biws/buswebservice";  // some xml string
            Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
            //string stringXml = "<soapenv:Envelope xmlns:com=\"com.busindia.webservices\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><com:GetAvailableServices xmls =\"\"><arg0><biFromPlace><placeCode>AMD</placeCode><placeID>208</placeID><placeName>AHMEDABAD</placeName></biFromPlace><biToPlace><placeCode>SRT</placeCode><placeID>317</placeID><placeName>SURAT</placeName></biToPlace><journeyDate>29/04/2015</journeyDate><wsUser><franchUserID>?</franchUserID><password>biteam</password><userID>474</userID><userKey>?</userKey><userName>team@busindia.com</userName><userRole>?</userRole><userStatus>?</userStatus><userType>101</userType></wsUser></arg0></com:GetAvailableServices></soapenv:Body></soapenv:Envelope>";  
            //  string stringXml=  Path.Combine(Package.Current.InstalledLocation.Path, "Test.xml");
            // XDocument xmlDoc = XDocument.Load("Test.xml");

            StorageFolder storageFolder = Package.Current.InstalledLocation;
            StorageFile storageFile = await storageFolder.GetFileAsync("Test.xml");
            string stringXml;
            stringXml = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);


            var httpClient = new Windows.Web.Http.HttpClient();
            var info = "biwstest:biwstest";
            var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
            httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
            httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
            Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
            httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
            IHttpContent content = new HttpStringContent(stringXml, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            httpRequestMessage.Content = content;
            Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);

            string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
            XmlDocument xDoc = new XmlDocument();

            xDoc.LoadXml(strXmlReturned);

            XDocument loadedData = XDocument.Parse(strXmlReturned);

                     

        }
       

    }
}
