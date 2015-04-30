using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class BusSearch : Page
    {
        public static BusSearch Current;
        string label = string.Empty;
        private DispatcherTimer _timer;
        public BusSearch()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            _timer = new DispatcherTimer();
            //Set your specific time here using TimeSpan instance
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += (s, e) => Tick();
            _timer.Start();

           
            
        }
        private void Tick()
        {
            _timer.Stop();
            ErrorPopup.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //_timer.Stop();
            var nav = (PlaceList)e.Parameter;

            if (e.Parameter != null)
            {
                string l1 = nav.Label;
                if (l1 == "fromlocation")
                {
                    lblSourceNameoneway.Text = nav.PlaceName;
                    lblSourceCodeNameoneway.Text = nav.PlaceCode;
                    lblSourceIDNameoneway.Text = nav.PlaceID;
                }
                else if (l1 == "tolocation")
                {
                    lblDestinationNameoneway.Text = nav.PlaceName;
                    lblDestinationCodeNameoneway.Text = nav.PlaceCode;
                    lblDestinationIDNameoneway.Text = nav.PlaceID;
                }
                else if (l1 == "fromlocationsearchreturn")
                {
                    lblSourcrReturnName.Text = nav.PlaceName;

                    stackBlueOne.Visibility = Visibility.Visible;
                    stackBlue.Visibility = Visibility.Collapsed;
                    OneWayGrid.Visibility = Visibility.Collapsed;
                    ReturnGrid.Visibility = Visibility.Visible;
                    //tabOneWay.Background = new SolidColorBrush(Colors.Transparent);
                    lblOneWay.Foreground = new SolidColorBrush(Colors.Black);
                    tabRoundTrip.Background = new SolidColorBrush(Colors.White);
                    lblRoundTrip.Foreground = new SolidColorBrush(Colors.Black);
                }
                else if (l1 == "tolocationsearchreturn")
                {
                    lblDestReturnName.Text = nav.PlaceName;

                    stackBlueOne.Visibility = Visibility.Visible;
                    stackBlue.Visibility = Visibility.Collapsed;
                    OneWayGrid.Visibility = Visibility.Collapsed;
                    ReturnGrid.Visibility = Visibility.Visible;
                    //tabOneWay.Background = new SolidColorBrush(Colors.Transparent);
                    lblOneWay.Foreground = new SolidColorBrush(Colors.Black);
                    tabRoundTrip.Background = new SolidColorBrush(Colors.White);
                    lblRoundTrip.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {

                }
            }

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;



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
        }
        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {

            //Indicate the back button press is handled so the app does not exit
            e.Handled = true;

        }
        public List<Scenario> Scenarios
        {
            get { return this.Scenarios; }
        }
        private void tabOneWay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            stackBlue.Visibility = Visibility.Visible;
            stackBlueOne.Visibility = Visibility.Collapsed;
            ReturnGrid.Visibility = Visibility.Collapsed;
            OneWayGrid.Visibility = Visibility.Visible;
            //tabRoundTrip.Background = new SolidColorBrush(Colors.Transparent);
            lblRoundTrip.Foreground = new SolidColorBrush(Colors.Black);
            tabOneWay.Background = new SolidColorBrush(Colors.White);
            lblOneWay.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tabRoundTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            stackBlueOne.Visibility = Visibility.Visible;
            stackBlue.Visibility = Visibility.Collapsed;
            OneWayGrid.Visibility = Visibility.Collapsed;
            ReturnGrid.Visibility = Visibility.Visible;
            //tabOneWay.Background = new SolidColorBrush(Colors.Transparent);
            lblOneWay.Foreground = new SolidColorBrush(Colors.Black);
            tabRoundTrip.Background = new SolidColorBrush(Colors.White);
            lblRoundTrip.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(Home));
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //MyAccountTab.Visibility = Visibility.Collapsed;
            //ContentPanel.Visibility = Visibility.Collapsed;
            ////cal.Visibility = Visibility.Visible;
        }

        private void calander_DisplayDateChanged(object sender, WinRTXamlToolkit.Controls.CalendarDateChangedEventArgs e)
        {
            MyAccountTab.Visibility = Visibility.Visible;
            ContentPanel.Visibility = Visibility.Visible;
            cal.Visibility = Visibility.Collapsed;
        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (lblSourceNameoneway.Text == "Select" || lblDestinationNameoneway.Text == "Select" )
            {
                PopupValidation.Visibility = Visibility.Visible;
            }
            else
            {
                BusSearchIn _objBusSerchIn = new BusSearchIn();
                _objBusSerchIn.placeCodeTo = lblDestinationCodeNameoneway.Text;
                _objBusSerchIn.placeIDFrom = lblSourceIDNameoneway.Text;
                _objBusSerchIn.placeIDTo = lblDestinationIDNameoneway.Text;
                _objBusSerchIn.placeCodeFrom = lblSourceCodeNameoneway.Text;
                _objBusSerchIn.Fromplace = lblSourceNameoneway.Text;
                _objBusSerchIn.Toplace = lblDestinationNameoneway.Text;
                _objBusSerchIn.Date = arrivalDatePicker.Date.ToString("dd MMM yyyy");
                this.Frame.Navigate(typeof(TripSearch), _objBusSerchIn);
               
            }
        }

        private void Border_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TripSearch));
        }

        private void Serch_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {

        }

        private void tabgreatSaving_Tapped(object sender, TappedRoutedEventArgs e)
        {
            stackBlueOne.Visibility = Visibility.Visible;
            stackBlue.Visibility = Visibility.Collapsed;
            OneWayGrid.Visibility = Visibility.Collapsed;
            ReturnGrid.Visibility = Visibility.Visible;
            //tabOneWay.Background = new SolidColorBrush(Colors.Transparent);
            lblOneWay.Foreground = new SolidColorBrush(Colors.Black);
            tabRoundTrip.Background = new SolidColorBrush(Colors.White);
            lblRoundTrip.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tapfromlocationsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            label = "fromlocation";
            this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
        }

        private void taptolocationsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            label = "tolocation";
            this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
        }

        private void tabfromlocationsearchreturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            label = "fromlocationsearchreturn";
            this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
        }

        private void tabtolocationsearchreturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            label = "tolocationsearchreturn";
            this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
        }

        private void imgSearchHistory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSearchHistory));
        }

        private void tapCloseValidationPopup_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupValidation.Visibility = Visibility.Collapsed;
        }

        private void tapSearchReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (lblSourcrReturnName.Text == "Select" || lblDestReturnName.Text == "Select")
            {
                PopupValidation.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    this.Frame.Navigate(typeof(TripSearch));
                }
                catch (Exception)
                {

                    throw;
                };
            }
        }
    }
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ///Convert Class throws exception so can not convert to date time
                string TheCurrentDate = value.ToString();

                string[] Values = TheCurrentDate.Split('/');
                string Day, Month, Year;

                Day = Values[1];
                Month = Values[0];
                Year = Values[2];

                string retvalue = string.Format("{0}/{1}/{2}", Day, Month, Year);
                return retvalue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BusSearchIn : INotifyPropertyChanged
    {
        string _Fromplace;
        string _Toplace;
        string _placeIDFrom;
        string _placeCodeFrom;
        string _placeIDTo;
        string _placeCodeTo;

        string _Date;
        public string Fromplace
        {
            get { return _Fromplace; }
            set { _Fromplace = value; }
        }
        public string Toplace
        {
            get { return _Toplace; }
            set { _Toplace = value; }
        }
        public string placeIDFrom
        {
            get { return _placeIDFrom; }
            set { _placeIDFrom = value; }
        }

        public string placeCodeFrom
        {
            get { return _placeCodeFrom; }
            set { _placeCodeFrom = value; }
        }

        public string placeIDTo
        {
            get { return _placeIDTo; }
            set { _placeIDTo = value; }
        }

        public string placeCodeTo
        {
            get { return _placeCodeTo; }
            set { _placeCodeTo = value; }
        }
        
        public string Date
        {
            get { return _Date; }
            set { _Date = value; NotifyPropertyChanged("PlaceName"); }
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
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
