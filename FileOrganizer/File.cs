using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FileOrganizer
{
    public class File
    {
        private string _currentLocation;
        private string _oldLocation;
        private string _movingTo;
        private string _author;
        private DateTime _creationDate;
        private DateTime _lastModified;
        private int _creationYear;
        private string _creationMonth;
        private int _size;

        public File()
        {

        }

        public File(string currentLocation)
        {
            _currentLocation = currentLocation;
            _oldLocation = currentLocation;
            // TODO: Code for setting author, creationDate, lastModified, size, creationMonth, CreationYear...
            /*
             * 
             */
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        public string OldLocation
        {
            get { return _oldLocation; }
        }

        public string MovingTo
        {
            get { return _movingTo; }
            set { _movingTo = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _movingTo = value; }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
        }

        public DateTime LastModified
        {
            get { return _lastModified; }
            set { _lastModified = value; }
        }

        public int CreationYear
        {
            get { return _creationYear; }
        }

        public string CreationMonth
        {
            get { return _creationMonth; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public bool PerformMove()
        {
            /* TODO: Code to perform move of file
             * 
             */

            return true;
        }
    }
}
