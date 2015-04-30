
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
    /// 
      
    public sealed partial class Test : Page
    {
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        ObservableCollection<Profile> UserProfileList = new ObservableCollection<Profile>();
        public Test()
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
       
        /**Add some static items to above UserProfileList**/
        private void Listloading()
        {
            UserProfileList.Add(new Profile { Name = "Subbu" });
            UserProfileList.Add(new Profile { Name = "Raju" });
            UserProfileList.Add(new Profile { Name = "Sudhar" });
            UserProfileList.Add(new Profile { Name = "Sudhar Sharma" });
            UserProfileList.Add(new Profile { Name = "Navadeep" });
            UserProfileList.Add(new Profile { Name = "Anuroop" });
            UserProfileList.Add(new Profile { Name = "Kalyan" });
            UserProfileList.Add(new Profile { Name = "Venky" });
            UserProfileList.Add(new Profile { Name = "Sai" });
            /**Finally bind list to our ListBox**/
            listBoxobj.ItemsSource = UserProfileList;

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
                    if ((textBlock1.Name == "NameTxt" || textBlock1.Name == "AddrTxt") && textBlock1.Text.ToUpper().Contains(SearchTextBox.Text.ToUpper()))
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

                int index = text.IndexOf(SearchTextBox.Text.ToUpper());//getting index of search text from listboxitem textblock 
                int lenth = SearchTextBox.Text.Length;

                if (!(index < 0))
                {

                    Run run = new Run() { Text = prevText.Substring(index, lenth) };
                    run.Foreground = new SolidColorBrush(Colors.Orange);//format search text color with orange 
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }

        private void listBoxobj_LayoutUpdated(object sender, object e)
        {

            if (LayoutUpdateFlag)
            {
                SearchVisualTree(listBoxobj);
            }
            LayoutUpdateFlag = false;
           
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listBoxobj.ItemsSource = UserProfileList.Where(w => w.Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()) );
            LayoutUpdateFlag = true;
        }
    }
    //public class Profile : INotifyPropertyChanged
    //{
    //    public string _name;
    //    public string _addr;
    //    public string Name
    //    {
    //        get { return _name; }
    //        set { _name = value; NotifyPropertyChanged("Name"); }
    //    }

    //    public string Address
    //    {
    //        get { return _addr; }
    //        set { _addr = value; NotifyPropertyChanged("Address"); }
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

}
