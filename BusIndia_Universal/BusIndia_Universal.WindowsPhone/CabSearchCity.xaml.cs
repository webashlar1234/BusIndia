using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CabSearchCity : Page
    {
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        ObservableCollection<CabCity1> CityList = new ObservableCollection<CabCity1>();
        public CabSearchCity()
        {
            this.InitializeComponent();
            Listloading();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Listloading()
        {
            CityList.Add(new CabCity1 { Name = "Mumbai" });
            CityList.Add(new CabCity1 { Name = "Delhi" });
            CityList.Add(new CabCity1 { Name = "Bangalore" });
            CityList.Add(new CabCity1 { Name = "Hyderabad" });
            CityList.Add(new CabCity1 { Name = "Ahmedabad" });
            CityList.Add(new CabCity1 { Name = "Chennai" });
            CityList.Add(new CabCity1 { Name = "Kolkata" });
            CityList.Add(new CabCity1 { Name = "Surat" });
            CityList.Add(new CabCity1 { Name = "Pune" });
            CityList.Add(new CabCity1 { Name = "Jaipur" });
            CityList.Add(new CabCity1 { Name = "Lucknow" });
            CityList.Add(new CabCity1 { Name = "Kanpur" });
            /**Finally bind list to our ListBox**/
            ListMenuItems.ItemsSource = CityList;

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
                    if ((textBlock1.Name == "NameTxt") && textBlock1.Text.ToUpper().Contains(txtSerchCity.Text.ToUpper()))
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
            Frame.Navigate(typeof(CabSearch));
        }

        private void txtSerchCity_DragLeave(object sender, DragEventArgs e)
        {
        }

        private void txtSerchCity_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txtSerchCity.Text != null && txtSerchCity.Text != "")
            {
                imgclearCity.Visibility = Visibility.Visible;
            }
            else
            {
                imgclearCity.Visibility = Visibility.Collapsed;
            }
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMenuItems.SelectedItem != null)
            {
                //Get selected favorites item value 
                var selecteditem = ListMenuItems.SelectedValue as string;

                Frame.Navigate(typeof(CabSearch), selecteditem);
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
            this.ListMenuItems.ItemsSource = CityList.Where(w => w.Name.ToUpper().Contains(txtSerchCity.Text.ToUpper()));
            LayoutUpdateFlag = true;
        }
    }

    public class CabCity1 : INotifyPropertyChanged
    {
        public string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
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
