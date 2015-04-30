using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSearchDepartureCity : Page
    {
        string parameter = string.Empty;
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        string selecteditem { get; set; }
        List<PlaceList> CityList = new List<PlaceList>();

        public BusSearchDepartureCity()
        {
            this.InitializeComponent();
            postXMLData1();
            //this.InitializeComponent();
            //string[] menuItems = new string[7] { "Bangalore", "Mangalore", "Pune", "Mumbai", "Surat", "Hyderabad", "Chennai" };
            //ListMenuItems.ItemsSource = menuItems.ToList();  //Set Menu list 

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                parameter = e.Parameter.ToString();
                switch (parameter)
                {
                    case "fromlocation":
                        parameter = "fromlocation";
                        break;
                    case "tolocation":
                        parameter = "tolocation";
                        break;
                    case "fromlocationsearchreturn":
                        parameter = "fromlocationsearchreturn";
                        break;
                    case "tolocationsearchreturn":
                        parameter = "tolocationsearchreturn";
                        break;
                }
            }
            // imgclearCity.Visibility = Visibility.Collapsed;
        }

        public async void postXMLData1()
        {
            string uri = "http://111.93.131.112/biws/buswebservice";  // some xml string
            Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
            //string stringXml = "<soapenv:Envelope xmlns:com=\"com.busindia.webservices\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><com:GetPlaceList xmls =\"\"><arg0><franchUserID>?</franchUserID><password>biteam</password><userID>474</userID><userKey>?</userKey><userName>team@busindia.com</userName><userRole>?</userRole><userStatus>?</userStatus><userType>101</userType></arg0></com:GetPlaceList></soapenv:Body></soapenv:Envelope>";
            string franchUserID = "?";
            string password = "biteam";
            int userID = 474;
            string userKey = "?";
            string username = "team@busindia.com";
            string userRole = "?";
            string userStatus = "?";
            int usertype = 101;
            WebServiceClassLiberary.Class1 listings = new WebServiceClassLiberary.Class1();
            XDocument element = listings.getList(franchUserID, password, userID, userKey, username, userRole, userStatus, usertype);
            string file = element.ToString();
            var httpClient = new Windows.Web.Http.HttpClient();
            var info = "biwstest:biwstest";
            var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
            httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
            httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
            Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
            httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
            IHttpContent content = new HttpStringContent(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            httpRequestMessage.Content = content;
            Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
            string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(strXmlReturned);
            XDocument loadedData = XDocument.Parse(strXmlReturned);
            var sdata = loadedData.Descendants("PlaceList").
            Select(x => new PlaceList
            {
                PlaceID = x.Element("placeID").Value,
                PlaceCode = x.Element("placeCode").Value,
                PlaceName = x.Element("placeName").Value
            });
            foreach (var item in sdata)
            {
                PlaceList pl = new PlaceList();
                pl.PlaceID = item.PlaceID;
                pl.PlaceName = item.PlaceName;
                pl.PlaceCode = item.PlaceCode;
                CityList.Add(pl);
            }
            ListMenuItems.ItemsSource = sdata;
        }

        private void SearchVisualTree(DependencyObject targetElement)
        {

            var count = VisualTreeHelper.GetChildrenCount(targetElement);//get count targeted dependecnyobject 

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);//detecting listboxitem child items 
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    prevText = textBlock1.Text;
                    if ((textBlock1.Name == "PlaceName") && textBlock1.Text.ToUpper().Contains(txtSerchCity.Text.ToUpper()))
                    {
                        HighlightText();//after finding textblock child item call method for highligh color 
                    }
                }
                else
                {
                    SearchVisualTree(child);//repeat method call until targeted dependency found child items 
                }
            }
        }

        /**This method is for highlight the search text**/
        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text.ToUpper();
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();

                int index = text.IndexOf(txtSerchCity.Text.ToUpper());//getting index of search text from listboxitem textblock 
                int lenth = txtSerchCity.Text.Length;

                if (!(index < 0))
                {

                    Run run = new Run() { Text = prevText.Substring(index, lenth) };
                    run.Foreground = new SolidColorBrush(Colors.Blue);//format search text color with orange 
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }
        private void txtBSerachGridResult_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusSearchCitySearchClass city = new BusSearchCitySearchClass { DepartureCityOneWay = txtSerchCity.Text };
            Frame.Navigate(typeof(BusSearch), city);
            //Frame.Navigate(typeof(BusSearch), txtBSerachGridResult.Text);
        }

        private void imgclearCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtSerchCity.Text = "";
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BusSearch));
        }

        private void txtSerchCity_DragLeave(object sender, DragEventArgs e)
        {
        }

        private void txtSerchCity_LostFocus(object sender, RoutedEventArgs e)
        {

            //if (txtSerchCity.Text != null && txtSerchCity.Text != "")
            //{
            //    imgclearCity.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    imgclearCity.Visibility = Visibility.Collapsed;
            //}
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListMenuItems.SelectedItem != null)
            {

                PlaceList myobject = ListMenuItems.SelectedItem as PlaceList;

                myobject.Label = parameter;

                Frame.Navigate(typeof(BusSearch), myobject);
            }
        }
        private void ListMenuItems_LayoutUpdated(object sender, object e)
        {
            if (LayoutUpdateFlag)
            {
                SearchVisualTree(ListMenuItems);
            }
            LayoutUpdateFlag = false;
        }

        private void txtSerchCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ListMenuItems.ItemsSource = CityList.Where(w => w.PlaceName.ToLower().Contains(txtSerchCity.Text.ToLower()));
            LayoutUpdateFlag = true;
        }
    }

    public class PlaceList : INotifyPropertyChanged
    {
        string _placeCode;
        string _placeID;
        string _placeName;

        public string PlaceCode
        {
            get { return _placeCode; }
            set { _placeCode = value; }
        }

        public string PlaceID
        {
            get { return _placeID; }
            set { _placeID = value; }
        }

        public string PlaceName
        {
            get { return _placeName; }
            set
            {
                _placeName = value;
                OnPropertyChanged("PlaceName");
            }
        }

        private string _Label;

        public string Label
        {
            get { return _Label; }
            set
            {
                _Label = value;

            }
        }
        private string _Cityname;

        public string Cityname
        {
            get { return _Cityname; }
            set
            {
                _Cityname = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            // Send an event notification that the property changed
            // This allows the UI to know when one of the items changes
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    //public class DepartureCity : INotifyPropertyChanged
    //{
    //    public string _name;

    //    public string Name
    //    {
    //        get { return _name; }
    //        set { _name = value; NotifyPropertyChanged("Name"); }
    //    }



    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void NotifyPropertyChanged(string property)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(property));
    //        }
    //    }
    //}
    public class contextparameter
    {
    }
}
