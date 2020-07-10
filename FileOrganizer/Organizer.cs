using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileOrganizer
{
    public static class Organizer
    {
        private static List<FOFile> _files = new List<FOFile>();
        // TODO: Make extensions customizable
        private static List<string> _extensions = new List<string>()
        {
            ".doc", ".docx", ".pdf", ".ppt", ".pptx", ".xls", ".xlsx"
        };
        private static string _folder;
        private static string _frequency;
        private static bool _byAuthor;
        private static long _totalSize = 0;
        private static long _completedSize = 0;
        private static object sizelock = new object();
        private static int processors = Environment.ProcessorCount;
        private static CountdownEvent counter;
        

        public static string Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public static bool OrganizeByAuthor
        {
            get { return _byAuthor; }
            set { _byAuthor = value; }
        }

        public static long TotalSize
        {
            get { return _totalSize; }
        }

        public static long CompletedSize
        {
            get { return _completedSize; }
        }

        public static string Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        public static void AddFolder(string path)
        {
            
            // Add files recursively by passing a path
            string[] fileArray = Directory.GetFiles(path);
            foreach(string fileString in fileArray)
            {
                // Only take in files with certain extensions
                if (_extensions.Contains(Path.GetExtension(fileString)))
                {
                    FOFile file = new FOFile(fileString);
                    AddFile(ref file);
                }
            }

            string[] subdirectories = Directory.GetDirectories(path);

            foreach(string subdirectory in subdirectories)
            {
                // Do not organize hidden directories
                if (!subdirectory.StartsWith('.'))
                {
                    AddFolder(subdirectory);
                }
            }
        }

        private static void AddFile(ref FOFile file)
        {
            _files.Add(file);

            // Add the file size to the count
            _totalSize += file.Size;
        }

        // TODO: Implement frequency and author selection.
        public static void Organize(bool performMove)
        {
            if (_files.Count > 20)
            {
                // Creating as many threads as you have logical processors
                int filesPerThread = _files.Count / (processors - 1);

                // A countdown event so we can "Join" the threads from the
                // threadpool.
                counter = new CountdownEvent(processors);
                int i = 0;
                FileBatch batch;
                while (i < (_files.Count - filesPerThread))
                {
                    batch = new FileBatch(i, filesPerThread, counter);
                    ThreadPool.QueueUserWorkItem(ProcessFileBatch, batch);
                    i += filesPerThread;
                }

                // One more thread to get the remainder.
                batch = new FileBatch(i, _files.Count - i,  counter);
                ThreadPool.QueueUserWorkItem(ProcessFileBatch, batch);

                // Wait for the counter to reach target
                // When counter reaches target, all threads
                // are done.
                counter.Wait();
            }
            else
            {
                foreach (FOFile file in _files)
                {
                    file.SetMoveLocation(_folder);
                    if (performMove)
                    {
                        // TODO: Uncomment this
                        //file.PerformMove();
                    }
                }
            }
        }

        public static int getProgress()
        {
            // TODO: Implement progress bar.
            int progress = (int)Math.Round((((double)_completedSize / _totalSize) * 100), MidpointRounding.AwayFromZero);
            return progress;
        }
        public static bool GenerateRestoreFile()
        {
            // TODO: Code for generating the manifest
            return true;
        }

        public static bool WriteRestoreFile()
        {
            // TODO: Code for writing manifest
            return true;
        }

        private static void ProcessFileBatch(object o)
        {

            FileBatch batch = o as FileBatch;

            for(int i = batch.Index; i < batch.Index + batch.Count; i++)
            {
                _files[i].SetMoveLocation(_folder);

                // We need a lock here because we have threads trying to access the same resourse
                lock (sizelock)
                {
                    _completedSize += _files[i].Size;
                }
            }

            // Signal the counter
            batch.Evt.Signal();
        }

        // Internal class for passing FileBatch object
        // to threads.
        internal class FileBatch
        {
            private int _index;
            private int _count;
            internal CountdownEvent Evt;

            internal int Index
            {
                get { return _index; }
                set { _index = value; }
            }

            internal int Count
            {
                get { return _count; }
                set { _count = value; }
            }
               

            internal FileBatch(int index, int count, CountdownEvent evt)
            {
                _index = index;
                _count = count;
                Evt = evt;
            }

        }
    }

    
}
