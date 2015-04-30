using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using System.Reflection;
using System.Windows;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {

        public Home()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.isUserLogin = false;
            CommonModel.bgImage = homeModel.bgBlurImage;
            homeModel.isUserLogin = CommonModel.isUserLogin;
            homeModel.isBusCodesAvailble = true;
            homeModel.isCabCodesAvailble = true;
            homeModel.isHotelCodesAvailble = true;
            if (CommonModel.isUserLogin)
            {
                homeModel.userImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/hdpi/home_logged_in.png", UriKind.RelativeOrAbsolute));
            }
            IList<OfferList> _TextLists = new List<OfferList>();
            OfferList item = new OfferList();
            item.OfferText = "500rs Off on hotel Booking 500rs Off on hotel Booking";
            item.OfferCode = "BIHOTEL500";
            _TextLists.Add(item);
            OfferList item1 = new OfferList();
            item1.OfferText = "100rs cashback on your cab Booking";
            item1.OfferCode = "BICAb100";
            _TextLists.Add(item1);
            OfferList item2 = new OfferList();
            item2.OfferText = "100rs Off on next bus Booking";
            item2.OfferCode = "BIBUS10000";
            _TextLists.Add(item2);
            for (int i = 0; i < 5; i++)
            {
                OfferList item3 = new OfferList();
                item3.OfferText = "200 Rs OFf on cab booking";
                item3.OfferCode = "BIBus200";
                _TextLists.Add(item3);

            }
            ListBoxBusCode.ItemsSource = _TextLists.ToList();
            //ListBoxHotelCodes.ItemsSource = _TextLists.ToList();
            //ListBoxCabCode.ItemsSource = _TextLists.ToList();
            List<MytripList> tripList = new List<MytripList>();
            for (int i = 0; i < 5; i++)
            {
                MytripList trip = new MytripList();
                trip.From = "BANGLORE" + i;
                trip.To = "MANGLORE" + i;
                trip.travelby = "BUS";
                trip.departtime = "10:30 AM";
                trip.arrivaltime = "3:30 PM";
                trip.datedepart = "18th feb 2015";
                tripList.Add(trip);
            }

            MyTripList.ItemsSource = tripList.ToList();
            this.DataContext = homeModel;
            this.InitializeComponent();
            Frame mainFrame = Window.Current.Content as Frame;
            mainFrame.ContentTransitions = null;
            UserImageLogo.Tapped += UserImageLogo_Tapped;
        }

        //public virtual void OnNavigatedTo(NavigationEventArgs e)
        //{

        //}
        public string settext(string copytext)
        {

            return "copied";
        }

        void UserImageLogo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginMain), UriKind.Relative);

            //  HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://demo.mapsearch360.com/WSSystems.svc/GetXPipelinesData/?id=1"));
            //  request.BeginGetResponse(new AsyncCallback(ReadCallback), request);
            //Frame rootFrame = Window.Current.Content as Frame;
            //if (rootFrame != null)
            //{
            //    rootFrame.Navigate(typeof(LoginMain));
            //    e.Handled = true;
            //}

            string url = "http://demo.mapsearch360.com/WSSystems.svc/GetXPipelinesData/?id=1";
            var response = httpRequest(url);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }

        //public string GetUrlData(string url1)
        //{
        //    string data = string.Empty;
        //    try
        //    {
        //        // Uri url =  new Uri("http://demo.mapsearch360.com/WSSystems.svc/GetXPipelinesData/?id=1");

        //        //WebRequest webRequest = WebRequest.Create(url);
        //        ////WebRequest webRequest = WebRequest.Create(HttpUtility.HtmlDecode(url));
        //        ////HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        //        //HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        //        //Stream receiveStream = response.GetResponseStream();
        //        //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
        //        //data = readStream.ReadToEnd();
        //        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        //        //request.Method = "GET";
        //        //using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
        //        //{

        //        //}

        //        //WebRequest request = WebRequest.Create(url);
        //        //return Task.Factory.FromAsync(request.BeginGetResponse, result =>
        //        //    {
        //        //        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
        //        //        string st = 
        //        //    });



        //        return data;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return data;
        //}

        public async Task<string> httpRequest(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string received;

            using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(responseStream))
                    {

                        received = await sr.ReadToEndAsync();
                    }
                }
            }

            return received;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            switch (PageNavigationMode.Mode)
            {
                case "Top":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                        break;
                    }
                case "Bottom":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Bottom } };
                        break;
                    }
                case "Left":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Left } };
                        break;
                    }
                case "Right":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Right } };
                        break;
                    }
                default:
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                        break;
                    }
            }
            //if (e.NavigationMode == NavigationMode.Back)
            //{
            //    Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
            //}
            //else
            //{
            //    Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Bottom } };
            //}
        }
        private void OpenClose_Left(object sender, RoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -100)
            {
                //ApplicationBar.IsVisible = true;
                MoveViewWindow(-300);
            }
            else
            {
                //ApplicationBar.IsVisible = false;
                MoveViewWindow(0);
            }
        }

        public void SelectLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginMain));
        }

        void MoveViewWindow(double left)
        {
            _viewMoved = true;
            ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = left;
            ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
        }

        private void canvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < 0)
                //MoveViewWindow(-300);
                Canvas.SetLeft(LayoutRoot, Convert.ToDouble(Math.Min(Math.Max(-300, Canvas.GetLeft(LayoutRoot) + e.Cumulative.Translation.X), 0)));
        }

        double initialPosition;
        bool _viewMoved = false;
        private void canvas_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            _viewMoved = false;
            initialPosition = Canvas.GetLeft(LayoutRoot);
        }

        private void canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            //if (_viewMoved)
            //    return;
            //if (Math.Abs(initialPosition - left) < 100)
            //{
            //    //bouncing back
            //    MoveViewWindow(initialPosition);
            //    return;
            //}
            ////change of state
            //if (initialPosition - left > 0)
            //{
            //    //slide to the left
            //    if (initialPosition > -300)
            //        MoveViewWindow(-300);
            //    else
            //        MoveViewWindow(-300);
            //}
            //else
            //{
            //    //slide to the right
            //    if (initialPosition < -300)
            //        MoveViewWindow(-300);
            //    else
            //        MoveViewWindow(0);
            //}

        }

        // Sample code for building a localized ApplicationBar


        private void Bus_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            this.Frame.Navigate(typeof(BusSearch));
        }
        private void Cabs_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            this.Frame.Navigate(typeof(CabSearch));
        }
        private void Hotels_Tap(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelSearchPage));
        }

        private void MyAccount_Tap(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyAccount));
        }
        private void MyItineraries_Tap(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyItinerary));
        }
        private void RateUs_Tap(object sender, TappedRoutedEventArgs e)
        {

        }
        private void ShareIt_Tap(object sender, TappedRoutedEventArgs e)
        {

        }
        private void Feedback_Tap(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FeedBack));
        }

        private void OfferItemTapped(object sender, TappedRoutedEventArgs e)
        {
            PopUpGrid.Visibility = Visibility.Visible;
            if (sender != null && sender is StackPanel)
            {
                StackPanel stack = sender as StackPanel;
                if (stack.DataContext is OfferList)
                {
                    OfferList offer = stack.DataContext as OfferList;
                    if (offer != null)
                    {
                        PopUpGrid.DataContext = offer;
                    }
                }
            }
        }

        private void OfferClose(object sender, RoutedEventArgs e)
        {
            PopUpGrid.Visibility = Visibility.Collapsed;

            //my_popup_xaml.IsOpen = false;

        }

        private void OfferCode_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //TextBox txtBox = (TextBox)sender;
            //txtOfferCode.SelectAll();
        }

        private void txtOfferCode_GotFocus(object sender, RoutedEventArgs e)
        {

            //Clipboard.SetValue();
            //txtOfferCode.SelectAll();
        }

        private void TripListItemTapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender != null && sender is StackPanel)
            {
                StackPanel stack = sender as StackPanel;
                if (stack.DataContext is MytripList)
                {
                    MytripList tripDetail = stack.DataContext as MytripList;
                    if (tripDetail != null)
                    {
                        this.Frame.Navigate(typeof(ReceiptPage), tripDetail);
                    }
                }
            }

        }


        private void MenuOpenClose(object sender, TappedRoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -100)
            {
                //ApplicationBar.IsVisible = true;
                MoveViewWindow(-300);
            }
            else
            {
                //ApplicationBar.IsVisible = false;
                MoveViewWindow(0);
            }
        }

        private void UserIconTapped(object sender, TappedRoutedEventArgs e)
        {
            //PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(LoginMain));
            //PageNavigationMode.Mode = PageTransmission.Bottom;
        }

        private void OfferCode_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var copytext = txtOfferCode.Text;
            settext(copytext);
        }
    }
}
