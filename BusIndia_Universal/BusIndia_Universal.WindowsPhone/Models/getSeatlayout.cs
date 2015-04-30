using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
    class getSeatlayout : INotifyPropertyChanged
    {
        private string _availableSeatNos;
        private string _bookedSeatNos;
        private string _conductorSeatNo;
        private string _ladiesAvailableSeatNos;
        private string _ladiesBookedSeatNos;
        private string _maxColCount;
        private string _maxRowCount;
        private string _column;
        private string _quota;
        private string _row;
        private string _seatNo;
        private string _seatStatus;
        private string _type;
        private string _totalSeats;
       

        public string availableSeatNos
        {
            get { return _availableSeatNos; }
            set { _availableSeatNos = value; }
        }
        public string bookedSeatNos
        {
            get { return _bookedSeatNos; }
            set { _bookedSeatNos = value; }
        }
        public string conductorSeatNo
        {
            get { return _conductorSeatNo; }
            set { _conductorSeatNo = value; }
        }
        public string ladiesAvailableSeatNos
        {
            get { return _ladiesAvailableSeatNos; }
            set { _ladiesAvailableSeatNos = value;}
        }
        public string ladiesBookedSeatNos
        {
            get { return _ladiesBookedSeatNos; }
            set
            {
                _ladiesBookedSeatNos = value;
            }
        }
        public string maxColCount
        {
            get { return _maxColCount; }
            set { _maxColCount = value; }
        }
        public string maxRowCount
        {
            get { return _maxRowCount; }
            set { _maxRowCount = value; }
        }
        public string column
        {
            get { return _column; }
            set { _column = value; }
        }
        public string quota
        {
            get { return _quota; }
            set { _quota = value; }
        }
        public string row
        {
            get { return _row; }
            set { _row = value; }
        }
        public string seatNo
        {
            get { return _seatNo; }
            set { _seatNo = value; }
        }
        public string seatStatus
        {
            get { return _seatStatus; }
            set { _seatStatus = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string totalSeats
        {
            get { return _totalSeats; }
            set { _totalSeats = value;}
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
