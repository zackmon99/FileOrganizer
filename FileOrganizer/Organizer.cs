using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        private static int processors = Environment.ProcessorCount;
        private static bool _performMove = false;
        private static CountdownEvent counter;
        private static HashSet<int> _uniqueYears = new HashSet<int>();
        private static Dictionary< int, Dictionary<string, HashSet<string> > > _yearMonthMap = 
            new Dictionary<int, Dictionary<string, HashSet<string>>>();
        private static object sizelock = new object();
        private static object _treeLock = new object();
        private static int _previewTreeProgress = 0;
        


        public static string Frequency { get; set; } = "";

        public static bool OrganizeByAuthor { get; set; } = false;

        public static long TotalSize { get; private set; } = 0;

        public static long CompletedSize { get; private set; } = 0;

        public static string Folder { get; set; } = "";

        public static List<string> UnauthorizedFolders { get; set; } = new List<string>();

        public static List<FOFile> Files
        {
            get { return _files; }
        }

        public static TreeNode PreviewTree { get; private set; } = new TreeNode("ROOT") { Name = "ROOT" };


        public static void Reinitialize()
        {
            _files = new List<FOFile>();
            Folder = "";
            Frequency = "";
            lock (sizelock)
            {
                TotalSize = 0;
                CompletedSize = 0;
            }
            _uniqueYears = new HashSet<int>();
            _yearMonthMap = new Dictionary<int, Dictionary<string, HashSet<string>>>();
            _performMove = false;
            PreviewTree = new TreeNode("ROOT") { Name = "ROOT" };
            _previewTreeProgress = 0;
        }

        public static void AddFolder(string path)
        {

            string[] fileArray;
            // Add files recursively by passing a path
            try
            {
                fileArray = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException e)
            {
                UnauthorizedFolders.Add(path);
                return;
            }
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
            TotalSize += file.Size;

            _uniqueYears.Add(file.CreationYear);
        }

        // TODO: Implement frequency and author selection.
        public static void Organize(bool performMove)
        {
            _performMove = performMove;
            if (_files.Count > processors + 20)
            {
                //Thread.Sleep(1000);
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
                //counter.Wait();
            }
            else
            {
                foreach (FOFile file in _files)
                {
                    file.SetMoveLocation(Folder);
                    if (_performMove)
                    {
                        // TODO: Uncomment this
                        //file.PerformMove();
                    }
                }
            }
        }

        // Get progress by looking at total size and completed size
        public static int getProgress()
        {
            if(TotalSize == 0)
            {
                return 0;
            }
            int progress = (int)Math.Round((((double)CompletedSize / TotalSize) * 100), MidpointRounding.AwayFromZero);
            return progress;
        }

        public static int getPreviewTreeProgress()
        {
            int progress = (int)Math.Round((((double)_previewTreeProgress / _files.Count) * 100), MidpointRounding.AwayFromZero);
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

        // Generates a TreeNode list that contains the directory structure of the given path
        public static List<TreeNode> GenerateFolderNodesRecursively(string path)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            string[] subdirectories = Directory.GetDirectories(path);
            if (!(subdirectories == null || subdirectories.Length == 0))
            {
                foreach (string subdirectory in subdirectories)
                {

                    TreeNode tree = new TreeNode(Path.GetFileName(subdirectory), GenerateFolderNodesRecursively(subdirectory).ToArray());
                    treeNodes.Add(tree);
                }
            }
            return treeNodes;
        }

        private static void ProcessFileBatch(object o)
        {

            FileBatch batch = o as FileBatch;

            for(int i = batch.Index; i < batch.Index + batch.Count; i++)
            {
                _files[i].SetMoveLocation(Folder);
                if (_performMove)
                {
                    // TODO: Uncomment this
                    // _files[i].PerformMove();
                }

                // We need a lock here because we have threads trying to access the same resourse
                
                //Thread.Sleep(100);
            }            
            // Signal the counter
            batch.Evt.Signal();
        }
        
        public static TreeNode GeneratePreview()
        {
            TreeNode tree = new TreeNode("ROOT") { Name = "ROOT" };

            if (_files.Count > processors + 20)
            {
                // Creating as many threads as you have logical processors
                int filesPerThread = _files.Count / (processors - 1);

                // A countdown event so we can "Join" the threads from the
                // threadpool.
                counter = new CountdownEvent(processors);
                int i = 0;
                FileTreeBatch batch;
                while (i < (_files.Count - filesPerThread))
                {
                    batch = new FileTreeBatch(i, filesPerThread, counter, tree);
                    ThreadPool.QueueUserWorkItem(AddFileToTree, batch);
                    i += filesPerThread;
                }

                // One more thread to get the remainder.
                batch = new FileTreeBatch(i, _files.Count - i, counter, tree);
                ThreadPool.QueueUserWorkItem(AddFileToTree, batch);

                //counter.Wait();
            }
            else
            {
                counter = new CountdownEvent(1);
                FileTreeBatch batch = new FileTreeBatch(0, _files.Count, null, tree);
                AddFileToTree(batch);
            }

            return tree;
        }

        public static void AddFileToTree(object o)
        {
            FileTreeBatch batch = o as FileTreeBatch;
            for(int i = batch.Index; i < batch.Index + batch.Count; i++)
            {
                string year = _files[i].CreationYear.ToString();
                string month = _files[i].CreationMonth;
                lock (_treeLock) {
                    if (!PreviewTree.Nodes.ContainsKey(year))
                    {
                        PreviewTree.Nodes.Add(new TreeNode(year) { Name = year });
                    }
                    if (!PreviewTree.Nodes[year].Nodes.ContainsKey(month))
                    {
                        PreviewTree.Nodes[year].Nodes.Add(new TreeNode(month) { Name = month });
                    }
                    if (!PreviewTree.Nodes[year].Nodes[month].Nodes.ContainsKey(_files[i].Name))
                    {
                        PreviewTree.Nodes[year].Nodes[month].Nodes.Add(new TreeNode(_files[i].Name) { Name = _files[i].Name });
                        _previewTreeProgress++;
                    }
                    else
                    {
                        string newName;
                        int k = 1;
                        newName = Path.GetFileNameWithoutExtension(_files[i].CurrentLocation) + ("({0})", k) + Path.GetExtension(_files[i].CurrentLocation);
                        while (PreviewTree.Nodes[year].Nodes[month].Nodes.ContainsKey(newName))
                        {
                            k++;
                            newName = Path.GetFileNameWithoutExtension(_files[i].CurrentLocation) + ("({0})", k) + Path.GetExtension(_files[i].CurrentLocation);
                        }
                        _files[i].NewName = newName;

                        PreviewTree.Nodes[year].Nodes[month].Nodes.Add(new TreeNode(newName) { Name = newName });

                        _previewTreeProgress++;

                    }
                }
                Thread.Sleep(100);
            }
            batch.Evt.Signal();
        }

        /*
        public static void GeneratePreview()
        {
            foreach(int year in _uniqueYears)
            {
                _yearMonthMap.Add(year, new Dictionary<string, HashSet<string>>());
            }
            if (_files.Count > processors + 20)
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
                    ThreadPool.QueueUserWorkItem(GetUniqueDateItems, batch);
                    i += filesPerThread;
                }

                // One more thread to get the remainder.
                batch = new FileBatch(i, _files.Count - i, counter);
                ThreadPool.QueueUserWorkItem(GetUniqueDateItems, batch);

                counter.Wait();
            }
            else
            {
                Dictionary<string, HashSet<string>> monthsFiles;
                HashSet<string> fileSet;
                foreach (FOFile file in _files)
                {
                    _yearMonthMap.TryGetValue(file.CreationYear, out monthsFiles);
                    if (!monthsFiles.ContainsKey(file.CreationMonth))
                    {
                        monthsFiles.Add(file.CreationMonth, new HashSet<string>());
                    }
                    monthsFiles.TryGetValue(file.CreationMonth, out fileSet);
                    if (!fileSet.Contains(file.Name))
                    {
                        fileSet.Add(file.Name);
                    }
                    else
                    {
                        string newName;
                        int k = 1;
                        newName = Path.GetFileNameWithoutExtension(file.CurrentLocation) + ("({0})", k) + Path.GetExtension(file.CurrentLocation);
                        while (fileSet.Contains(newName))
                        {
                            k++;
                            newName = Path.GetFileNameWithoutExtension(file.CurrentLocation) + ("({0})", k) + Path.GetExtension(file.CurrentLocation);
                        }
                        file.NewName = newName;
                        fileSet.Add(newName);
                    }

                }
            }
        }

        private static void GetUniqueDateItems(object o)
        {
            FileBatch batch = o as FileBatch;
            Dictionary<string, HashSet<string>> monthsFiles;
            HashSet<string> fileSet;
            for (int i = batch.Index; i < batch.Index + batch.Count; i++)
            {
                lock (_yearMonthMapLock)
                {
                    _yearMonthMap.TryGetValue(_files[i].CreationYear, out monthsFiles);
                    if (!monthsFiles.ContainsKey(_files[i].CreationMonth))
                    {
                        monthsFiles.Add(_files[i].CreationMonth, new HashSet<string>());
                    }
                    monthsFiles.TryGetValue(_files[i].CreationMonth, out fileSet);
                    if (!fileSet.Contains(_files[i].Name))
                    {
                        fileSet.Add(_files[i].Name);                   
                    }
                    else
                    {
                        string  newName;
                        int k = 1;
                        newName = Path.GetFileNameWithoutExtension(_files[i].CurrentLocation) + ("({0})", k) + Path.GetExtension(_files[i].CurrentLocation);
                        while (fileSet.Contains(newName))
                        {
                            k++;
                            newName = Path.GetFileNameWithoutExtension(_files[i].CurrentLocation) + ("({0})", k) + Path.GetExtension(_files[i].CurrentLocation);
                        }
                        _files[i].NewName = newName;
                        fileSet.Add(newName);
                    }
                }

            }
            batch.Evt.Signal();
        }

        public static void GeneratePreviewTree()
        {
            
            Dictionary<int, Dictionary<string, HashSet<string>>>.KeyCollection yearKeys = _yearMonthMap.Keys;
            List<TreeNode> nodes = new List<TreeNode>();
            foreach(int yearKey in yearKeys) {
                TreeNode tree = new TreeNode(yearKey.ToString(), GetMonthsInYear(yearKey).ToArray());
                nodes.Add(tree);
            }

            _treeNodes = new List<TreeNode>(nodes);
            


        }
    */

        private static List<TreeNode> GetFilesInMonth(int year, string month, Dictionary<string, HashSet<string>> months)
        {
            HashSet<string> fileSet;
            months.TryGetValue(month, out fileSet);
            List<TreeNode> nodes = new List<TreeNode>();
            foreach(string file in fileSet)
            {
                nodes.Add(new TreeNode(file));
            }

            return nodes;
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

        internal class FileNodeBatch : FileBatch
        {
            internal static List<TreeNode> _nodes;
            internal static object _lockObject = new object();
            internal int _year;
            internal string _month;

            internal FileNodeBatch(int index, int count, CountdownEvent evt, int year, string month) : base(index, count, evt)
            {
                _year = year;
                _month = month;
                _nodes = new List<TreeNode>();
            }

            internal void Add(TreeNode node)
            {
                lock (_lockObject)
                {
                    _nodes.Add(node);
                }
            }
        }

        internal class FileTreeBatch : FileBatch
        {
            private TreeNode _tree;
            private static object _treeLock = new object();

            internal FileTreeBatch(int index, int count, CountdownEvent evt, TreeNode tree) : base(index, count, evt)
            {
                _tree = tree;
            }

            internal TreeNode Tree
            {
                get { return _tree; }
                set { _tree = value; }
            }

            internal object TreeLock
            {
                get { return _treeLock; }
            }
        }
    }

    
}
