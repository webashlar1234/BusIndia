using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
    class getBoardingPoints : INotifyPropertyChanged
    {
        private string _platformNo;
        private string _pointID;
        private string _pointName;
        private string _Time;
        private string _Type;

        public string platformNo
        {
            get { return _platformNo; }
            set { _platformNo = value; }
        }
        public string pointID
        {
            get { return _pointID; }
            set { _pointID = value; }
        }
        public string pointName
        {
            get { return _pointName; }
            set { _pointName = value; }
        }
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public string Type
        {
            get { return _Type; }
            set {_Type = value; }
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
