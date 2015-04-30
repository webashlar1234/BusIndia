using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone;
using Windows.UI;
using Windows.UI.Xaml.Markup;
using Windows.Data.Xml.Dom;
using Windows.Web.Http;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Storage;
using BusIndia_Universal.Models;
using System.Globalization;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripSearch : Page
    {
        int min = 0;
        int max = 0;
        public TripSearch()
        {
            this.InitializeComponent();
            max = Convert.ToInt32(txtBMaxPrice.Text);
            LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
        }
        List<GetAvailableService> availableservice = new List<GetAvailableService>();

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 

        public async void postXMLData1()
        {
            string uri = "http://111.93.131.112/biws/buswebservice";  // some xml string
            Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
            string franchUserID = "?";
            string password = "biteam";
            int userID = 474;
            string userKey = "?";
            string username = "team@busindia.com";
            string userRole = "?";
            string userStatus = "?";
            int usertype = 101;

            string FromplaceName = txtBFromLocationT.Text;
            string ToplaceName = txtBToLocationT.Text;
            string placeIDFrom = txtBFromID.Text;
            string placeCodeFrom = txtBFromCode.Text;
            string placeIDTo = txtBToID.Text;
            string placeCodeTo = txtBToCode.Text;

            string d = txtBDateTab.Text;
            System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
            txtBDateTab.Text = dt.ToString("dd/MM/yyyy");

            string Date = txtBDateTab.Text;

            WebServiceClassLiberary.Class1 listings = new WebServiceClassLiberary.Class1();
            XDocument element = listings.getservice(franchUserID, password, userID, userKey, username, userRole, userStatus, usertype, placeIDFrom, placeCodeFrom, FromplaceName, placeIDTo, placeCodeTo, ToplaceName, Date);
            string stringXml = element.ToString();
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

            var sdata = loadedData.Descendants("service").
            Select(x => new GetAvailableService
            {
                arrivalDate = x.Element("arrivalDate").Value,
                arrivalTime = x.Element("arrivalTime").Value,
                classID = x.Element("classID").Value,
                classLayoutID = x.Element("classLayoutID").Value,
                className = x.Element("className").Value,
                corpCode = x.Element("corpCode").Value,
                departureTime = x.Element("departureTime").Value,
                destination = x.Element("destination").Value,
                fare = x.Element("fare").Value,
                journeyDate = x.Element("journeyDate").Value,
                journeyHours = x.Element("journeyHours").Value,
                maxSeatsAllowed = x.Element("maxSeatsAllowed").Value,
                origin = x.Element("origin").Value,
                //placeIDFrom = x.Element("biFromPlace").Attribute("placeID").Value,
                //placeIDto = x.Element("biToPlace").Attribute("placeID").Value,
                refundStatus = x.Element("refundStatus").Value,
                routeNo = x.Element("routeNo").Value,
                seatsAvailable = x.Element("seatsAvailable").Value,
                seatStatus = x.Element("seatStatus").Value,
                serviceID = x.Element("serviceID").Value,
                startPoint = x.Element("startPoint").Value,
                stuID = x.Element("stuID").Value,
                tripCode = x.Element("tripCode").Value
            });
            foreach (var item in sdata)
            {
                GetAvailableService gas = new GetAvailableService();
                gas.arrivalDate = item.arrivalDate;
                gas.arrivalTime = item.arrivalTime;
                gas.classID = item.classID;
                gas.classLayoutID = item.classLayoutID;
                gas.className = item.className;
                gas.corpCode = item.corpCode;
                gas.departureTime = item.departureTime;
                gas.destination = item.destination;
                gas.fare = item.fare;
                gas.journeyDate = item.journeyDate;
                gas.journeyHours = item.journeyHours;
                gas.maxSeatsAllowed = item.maxSeatsAllowed;
                gas.origin = item.origin;
                gas.placeIDFrom = item.placeIDFrom;
                gas.placeIDto = item.placeIDto;
                gas.refundStatus = item.refundStatus;
                gas.routeNo = item.routeNo;
                gas.seatsAvailable = item.seatsAvailable;
                gas.seatStatus = item.seatStatus;
                gas.serviceID = item.serviceID;
                gas.startPoint = item.startPoint;
                gas.stuID = item.stuID;
                gas.tripCode = item.tripCode;
                gas.viaPlaces = item.viaPlaces;
                availableservice.Add(gas);
            }
            ListMenuItems.ItemsSource = sdata;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var nav = (BusSearchIn)e.Parameter;
            txtBFromLocationT.Text = nav.Fromplace;
            txtBToLocationT.Text = nav.Toplace;
            txtBDateTab.Text = nav.Date;
            txtBFromCode.Text = nav.placeCodeFrom;
            txtBFromID.Text = nav.placeIDFrom;
            txtBToCode.Text = nav.placeCodeTo;
            txtBToID.Text = nav.placeIDTo;
            postXMLData1();
        }

        private void PreviousDayTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string d = txtBDateTab.Text;
            System.DateTime dt = System.DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
            dt = dt.AddDays(-1);
            txtBDateTab.Text = dt.ToString("dd MMM yyyy");
            postXMLData1();
        }

        private void DateTab_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void tabRoundTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string d = txtBDateTab.Text;
            System.DateTime dt = System.DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
            dt = dt.AddDays(1);
            txtBDateTab.Text = dt.ToString("dd MMM yyyy");
            postXMLData1();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PasangerInformation));
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSearch));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }

        private void imgFilter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Thickness margin = new Thickness(0, 0, 0, 0);
            if (LayoutRoot.Margin == margin)
            {
                LayoutRoot.Margin = new Thickness(-300, 0, 300, 0);
                LayoutRoot2.Visibility = Visibility.Visible;
            }
            else
            {
                LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
                LayoutRoot2.Visibility = Visibility.Collapsed;
            }

        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BrdBAvailableSeatsP_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BrdBAvailableSeatsN_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void OneWayGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSeatSelection));
        }

        private void OneWayGridP_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSeatSelection));
        }

        private void OneWayGridN_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSeatSelection));
        }

        private void SliderZoom_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void imgCorporation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CorporationGrid.Visibility = Visibility.Visible;

        }

        private void txtCorporation_GotFocus(object sender, RoutedEventArgs e)
        {
            CorporationGrid.Visibility = Visibility.Visible;
        }

        private void imgBusType_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void txtBusType_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void AllCorporation_Checked(object sender, RoutedEventArgs e)
        {
            txtCorporation.Text = "ALL";
            CorporationGrid.Visibility = Visibility.Collapsed;
        }

        private void AllCorporation_Unchecked(object sender, RoutedEventArgs e)
        {
            txtCorporation.Text = "ALL";
            CorporationGrid.Visibility = Visibility.Collapsed;
        }

        private void GRTCCorporation_Checked(object sender, RoutedEventArgs e)
        {
            txtCorporation.Text = "GSRTC";
            CorporationGrid.Visibility = Visibility.Collapsed;
        }

        private void GRTCCorporation_Unchecked(object sender, RoutedEventArgs e)
        {
            txtCorporation.Text = "ALL";
            CorporationGrid.Visibility = Visibility.Collapsed;
        }

        private void AllBusTypes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AllBusTypes_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void NonACSleeperCBusTypes_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void NonACSleeperCBusTypes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LuxuryBusTypes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LuxuryBusTypes_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SleeperBusTypes_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SleeperBusTypes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListMenuItems_LayoutUpdated(object sender, object e)
        {

        }

        private void priceFilterSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (ListMenuItems != null)
            {
                string pricetexts = Convert.ToString(e.NewValue);
                ListMenuItems.ItemsSource = availableservice.Where(w => Convert.ToInt32(w.fare) >= e.NewValue && Convert.ToInt32(w.fare) <= max);
            }
        }

        private void timeFilterSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(ListMenuItems != null)
            {
                int maxtime = Convert.ToInt32(lasthour.Text);
                ListMenuItems.ItemsSource = availableservice.Where(w => Convert.ToInt32(w.journeyHours) >= e.NewValue && Convert.ToInt32(w.journeyHours) <= maxtime);
            }
        }
    }
}
