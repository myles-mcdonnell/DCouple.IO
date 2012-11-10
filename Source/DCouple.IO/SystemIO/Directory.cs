//   Copyright 2011 Myles McDonnell (myles.mcdonnell.public@gmail.com)

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace DCouple.IO.SystemIO
{
    /// <summary>
    /// Represents an existing Directory
    /// </summary>
    public class Directory : IDirectory
    {
        private readonly DirectoryInfo _directoryInfo;

        internal Directory(string path)
        {
            _directoryInfo = new DirectoryInfo(path);
        }

        internal Directory(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo;
        }

        /// <summary>
        /// The parent <see cref="IDirectory"/> of this instance
        /// </summary>
        public IDirectory Parent
        {
            get { return (_directoryInfo.Parent == null) ? null : new Directory(_directoryInfo.Parent); }
        }

        /// <summary>
        /// The directory name
        /// </summary>
        public string Name
        {
            get { return _directoryInfo.Name; }
        }

        /// <summary>
        /// The directory file attributes, such as read-only etc.
        /// </summary>
        public FileAttributes Attributes
        {
            get { return _directoryInfo.Attributes; }
            set { _directoryInfo.Attributes = value; }
        }

        public DateTime CreationTime
        {
            get { return _directoryInfo.CreationTime; }
            set { _directoryInfo.CreationTime = value; }
        }

        public DateTime CreationTimeUtc
        {
            get { return _directoryInfo.CreationTimeUtc; }
            set { _directoryInfo.CreationTimeUtc = value; }
        }

        public DateTime LastAccessTime
        {
            get { return _directoryInfo.LastAccessTime; }
            set { _directoryInfo.LastAccessTime = value; }
        }

        public DateTime LastAccessTimeUtc
        {
            get { return _directoryInfo.LastAccessTimeUtc; }
            set { _directoryInfo.LastAccessTimeUtc = value; }
        }

        public DateTime LastWriteTime
        {
            get { return _directoryInfo.LastWriteTime; }
            set { _directoryInfo.LastWriteTime = value; }
        }

        public DateTime LastWriteTimeUtc
        {
            get { return _directoryInfo.LastWriteTimeUtc; }
            set { _directoryInfo.LastWriteTimeUtc = value; }
        }

        /// <summary>
        /// A collection of the files contained in this directory
        /// </summary>
        public IEnumerable<IFile> Files
        {
            get
            {
                return _directoryInfo.GetFiles().Select(file => new File(file)).ToList();
            }
        }

        /// <summary>
        /// Returns true if this directory exists at the root of it's <see cref="Directory.FileSystem"/>
        /// </summary>
        public bool IsRoot
        {
            get { return Root == null ? false : Root.FullName == FullName ; }
        }

        /// <summary>
        /// A collection os sub-directories
        /// </summary>
        public IEnumerable<IDirectory> Directories
        {
            get
            {
                return _directoryInfo.GetDirectories().Select(directory => new Directory(directory));
            }
        }

        /// <summary>
        /// The full name or path of this instance, e.g. c:\temp\this_directory
        /// </summary>
        public string FullName
        {
            get { return _directoryInfo.FullName; }
        }

        /// <summary>
        /// Copies this contents of this directory to another directory
        /// </summary>
        /// <param name="directory">The target directory.  Will be created if not exists</param>
        /// <param name="recursive">Will copy all sub directories and contents if true</param>
        /// <param name="overwrite">Will overwrite existing files if true</param>
        public void CopyTo(IDirectory directory, bool recursive, bool overwrite)
        {
            var stack = new Stack<Tuple<string, string>>();
            stack.Push(new Tuple<string, string>(FullName, directory.FullName));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();

                if (!System.IO.Directory.Exists(folders.Item2))
                    System.IO.Directory.CreateDirectory(folders.Item2);

                foreach (var file in System.IO.Directory.GetFiles(folders.Item1, "*.*"))
                    System.IO.File.Copy(file, Path.Combine(folders.Item2, Path.GetFileName(file)), overwrite);

                if (recursive)
                    foreach (var folder in System.IO.Directory.GetDirectories(folders.Item1))
                        stack.Push(new Tuple<string, string>(folder, Path.Combine(folders.Item2, Path.GetFileName(folder))));
            }
        }

        /// <summary>
        /// The directory at the root of this directory tree
        /// </summary>
        public IDirectory Root
        {
            get { return _directoryInfo.Root==null ? null : new Directory(_directoryInfo.Root); }
        }

        /// <summary>
        /// Creates a new sub directory in this directory
        /// </summary>
        /// <param name="name">the name of the new directory</param>
        /// <returns>A <see cref="IDirectory"/> instance representing the new sub directory</returns>
        public IDirectory CreateDirectory(string path, DirectorySecurity directorySecurity)
        {
			return new Directory(_directoryInfo.CreateSubdirectory(path, directorySecurity));
        }

         /// <summary>
        /// Creates a new sub directory in this directory
        /// </summary>
        /// <param name="name">the name of the new directory</param>
        /// <returns>A <see cref="IDirectory"/> instance representing the new sub directory</returns>
        public IDirectory CreateDirectory(string path)
        {
            return new Directory(_directoryInfo.CreateSubdirectory( path));
        }

        public void Delete(bool recursive = false)
        {
            _directoryInfo.Delete(recursive);
        }

        public IEnumerable<IFile> FindFiles(string searchPattern, bool recursive = false)
        {
            return  _directoryInfo.EnumerateFiles(searchPattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Select(fileInfo => new File(fileInfo)).ToList();
        }

        public IEnumerable<IDirectory> FindDirectories(string searchPattern, bool recursive = false)
        {
            return _directoryInfo.EnumerateDirectories(searchPattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Select(dirInfo => new Directory(dirInfo)).ToList();
        }

        public bool Exists
        {
            get
            {
                return _directoryInfo.Exists;
            }
        }

        public void Refresh()
        {
            _directoryInfo.Refresh();
        }

        public void Create()
        {
            _directoryInfo.Create();
        }
    }
}
