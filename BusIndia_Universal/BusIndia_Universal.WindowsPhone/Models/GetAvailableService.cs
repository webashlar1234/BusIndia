using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
    class GetAvailableService :INotifyPropertyChanged
    {
        private  string _arrivalDate;
        private  string _arrivalTime;
        private string _placeIDFrom;
        private string _placeIDto;
        private string _classID;
        private  string _classLayoutID;
        private  string _className;
        private string _corpCode;
        private string _departureTime;
        private string _destination;
        private  string _fare;
        private  string _journeyDate;
        private string _journeyHours;
        private string _maxSeatsAllowed;
        private string _origin;
        private  string _refundStatus;
        private  string _routeNo;
        private string _seatStatus;
        private string _seatsAvailable;
        private string _serviceID;
        private string _startPoint;
        private string _stuID;
        private  string _tripCode;
        private  string _viaPlaces;
      
        public string arrivalDate
        {
            get { return _arrivalDate; }
            set { _arrivalDate = value; }
        }

        public string arrivalTime
        {
            get { return _arrivalTime; }
            set { _arrivalTime = value; }
        }
        public string placeIDFrom
        {
            get { return _placeIDFrom; }
            set { _placeIDFrom = value; NotifyPropertyChanged("PlaceName"); }
        }     
        public string placeIDto
        {
            get { return _placeIDto; }
            set
            {
                _placeIDto = value;

            }
        }
        public string classID
        {
            get { return _classID; }
            set
            {
                _classID = value;
            }
        }
        public string classLayoutID
        {
            get { return _classLayoutID; }
            set { _classLayoutID = value; }
        }
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }
        public string corpCode
        {
            get { return _corpCode; }
            set { _corpCode = value; }
        }
        public string departureTime
        {
            get { return _departureTime; }
            set {_departureTime = value; }
        }
        public string destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public string fare
        {
            get { return _fare; }
            set { _fare = value; }
        }
        public string journeyDate
        {
            get { return _journeyDate; }
            set { _journeyDate = value; }
        }
        public string journeyHours
        {
            get { return _journeyHours; }
            set { _journeyHours = value; }
        }
        public string maxSeatsAllowed
        {
            get { return _maxSeatsAllowed; }
            set
            {
                _maxSeatsAllowed = value;

            }
        }
        public string origin
        {
            get { return _origin; }
            set {_origin = value; }
        }
        public string refundStatus
        {
            get { return _refundStatus; }
            set { _refundStatus = value; }
        }
        public string routeNo
        {
            get { return _routeNo; }
            set { _routeNo = value; }
        }
        public string seatStatus
        {
            get { return _seatStatus; }
            set {_seatStatus = value; }
        }
        public string seatsAvailable
        {
            get { return _seatsAvailable; }
            set { _seatsAvailable = value;}
        }
        public string serviceID
        {
            get { return _serviceID; }
            set { _serviceID = value; }
        }
        public string startPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }
        public string stuID
        {
            get { return _stuID; }
            set { _stuID = value; }
        }
        public string tripCode
        {
            get { return _tripCode; }
            set { _tripCode = value; }
        }

        public string viaPlaces
        {
            get { return _viaPlaces; }
            set { _viaPlaces = value; }
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
