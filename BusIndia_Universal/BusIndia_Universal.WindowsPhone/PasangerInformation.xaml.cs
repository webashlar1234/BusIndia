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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasangerInformation : Page
    {
        public PasangerInformation()
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

       
        private void rdbtnfemale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Collapsed;
            txtGender.Text = "Female";
        }

        private void rdbtnMale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Collapsed;
            txtGender.Text = "Male";
        }
        private void txtGender_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusBookingSummary));
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {

            CheckBox cb = sender as CheckBox;
            
            if(cb.IsChecked == false)
            {
                cb.IsChecked = true;
            }
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {

            CheckBox cb = sender as CheckBox;
            if(cb.IsChecked == true)
            {
                cb.IsChecked = false;
            }
        }

      

        private void imgGender2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid2.Visibility = Visibility.Visible;
        }

        private void imgGender1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Visible;
        }

        private void rdbtnMale2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid2.Visibility = Visibility.Collapsed;
            txtGenderP2.Text = "Male";
        }

        private void rdbtnfemale2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid2.Visibility = Visibility.Collapsed;
            txtGenderP2.Text = "Female";
        }

        private void txtGender_GotFocus_1(object sender, RoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Visible;
        }

        private void txtGenderP2_GotFocus(object sender, RoutedEventArgs e)
        {
            GenderPopUpGrid2.Visibility = Visibility.Visible;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
