using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace FileOrganizer
{
    public class FOFile
    {
        private string _currentLocation;
        private string _oldLocation;
        private string _movingTo;
        private string _author;
        private DateTime _creationDate;
        private DateTime _lastModified;
        private int _creationYear;
        private string _creationMonth;
        private long _size;

        public FOFile()
        {

        }

        public FOFile(string currentLocation)
        {
            _currentLocation = currentLocation;
            _oldLocation = currentLocation;
            try
            {
                _creationDate = File.GetCreationTime(_currentLocation);
            }
            catch (Exception)
            {
                // TODO: Figure out exceptions for creating FOFile
            }
            _lastModified = File.GetLastWriteTime(_currentLocation);
            _creationYear = _creationDate.Year;
            _creationMonth = _creationDate.ToString("MMM");
            try
            {
                _size = new FileInfo(_currentLocation).Length;
            }
            catch (Exception)
            {
                _size = 0;
            }
            // TODO: Code for setting author
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

        // TODO: Implement author in file class
        /*
        public string Author
        {
            get { return _author; }
            set { _movingTo = value; }
        }
        */

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

        public long Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public void SetMoveLocation(string folder)
        {
            try
            {
                Monitor.Enter(this);
                _movingTo = folder + "\\" + _creationYear + "\\" + _creationMonth;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public bool PerformMove()
        {
            try
            {
                Monitor.Enter(this);
                File.Move(_currentLocation, _movingTo);
                _currentLocation = _movingTo;
                _movingTo = null;
            }
            finally
            {
                Monitor.Exit(this);
            }

            return true;
        }
    }
}
