using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
    class getIDProofs : INotifyPropertyChanged
    {
        private string _idProofID;
        private string _idProofName;

        public string idProofID
        {
            get { return _idProofID; }
            set { _idProofID = value; }
        }
        public string idProofName
        {
            get { return _idProofName; }
            set { _idProofName = value; }
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
