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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSeatSelection : Page
    {
        int number;
        bool booked = true;
        public BusSeatSelection()
        {
            this.InitializeComponent();

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


        }

        private void stackCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void stackDone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusPickDropPoint));
        }

        private void imgr0c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //BitmapImage Empty = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_empty_seat.png", UriKind.Absolute));
            if (booked)
            {
                BitmapImage Select = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_empty_seat.png", UriKind.Absolute));
                imgr0c0.Source = Select;
                number = number + 1;
                txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
                booked = false;
            }
            else
            {
                BitmapImage Empty = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_empty_seat.png", UriKind.Absolute));
                imgr0c0.Source = Empty;
                number = number - 1;
                txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
                booked = false;
            }


            //if (imgr0c0.Source == Empty)
            //{
            //    imgr0c0.Source = Select;
            //    number = number + 1;
            //    txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
            //}
            //else if (imgr0c0.Source == Select)
            //{
            //    imgr0c0.Source = Empty;
            //    number = number - 1;
            //    txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
            //}
            //else
            //{

            //}
        }

        private void imgr0c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr0c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr0c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr0c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }



        private void imgr1c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr1c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr1c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr1c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }



        private void imgr2c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr2c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr2c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr2c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }


        private void imgr1c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr1c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr1c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr1c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr2c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr2c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr2c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr2c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr3c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr3c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr3c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr3c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr3c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr3c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr3c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr3c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr4c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr4c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr4c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr4c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr5c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr5c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr5c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr5c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr5c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr5c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr5c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr5c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr6c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr6c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr6c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr6c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr6c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr6c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr6c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr6c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr7c0_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr7c0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr7c1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr7c1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr7c2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr7c2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr7c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr7c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }

        private void imgr0c3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgr0c3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
            number = number + 1;
            txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
        }
    }
}
