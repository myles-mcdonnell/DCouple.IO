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
using System.IO;

namespace DCouple.IO.SystemIO
{
    public class File : IFile
    {
        private readonly FileInfo _fileInfo;

        internal File(string path)
        {
            _fileInfo = new FileInfo(path);
        }

        internal File(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public IDirectory Parent
        {
            get { return (_fileInfo.Directory == null) ? null : new Directory(_fileInfo.Directory); }
        }

        public string FullName
        {
            get
            {
                return _fileInfo.FullName;
            }
        }

        public string Name
        {
            get { return _fileInfo.Name; }
        }

        public string Extension
        {
            get { return _fileInfo.Extension; }
        }

        public IDirectory Root
        {
            get { return Parent.Root; }
        }

        public void CopyTo(IDirectory directory, bool overwrite)
        {
            CopyTo(directory, Name, overwrite);
        }

        public void CopyTo(IDirectory directory, string fileName, bool overwrite)
        {
            _fileInfo.CopyTo(string.Format("{0},{1},{2}", directory.FullName, System.IO.Path.DirectorySeparatorChar, fileName), overwrite);
        }

        public void MoveTo(IDirectory directory)
        {
            MoveTo(directory, Name);
        }

        public void MoveTo(IDirectory directory, string fileName)
        {
            _fileInfo.MoveTo(string.Format("{0},{1},{2}", directory.FullName, System.IO.Path.DirectorySeparatorChar, fileName));
        }

        public void Delete()
        {
            _fileInfo.Delete();
        }

        public FileAttributes Attributes
        {
            get { return _fileInfo.Attributes; }
            set { _fileInfo.Attributes = value; }
        }

        public DateTime CreationTime
        {
            get { return _fileInfo.CreationTime; }
            set { _fileInfo.CreationTime = value; }
        }

        public DateTime CreationTimeUtc
        {
            get { return _fileInfo.CreationTimeUtc; }
            set { _fileInfo.CreationTimeUtc = value; }
        }

        public bool IsReadOnly
        {
            get { return _fileInfo.IsReadOnly; }
            set { _fileInfo.IsReadOnly = value; }
        }

        public DateTime LastAccessTime
        {
            get { return _fileInfo.LastAccessTime; }
            set { _fileInfo.LastAccessTime = value; }
        }

        public DateTime LastAccessTimeUtc
        {
            get { return _fileInfo.LastAccessTimeUtc; }
            set { _fileInfo.LastAccessTimeUtc = value; }
        }

        public DateTime LastWriteTime
        {
            get { return _fileInfo.LastWriteTime; }
            set { _fileInfo.LastWriteTime = value; }
        }

        public DateTime LastWriteTimeUtc
        {
            get { return _fileInfo.LastWriteTimeUtc; }
            set { _fileInfo.LastWriteTimeUtc = value; }
        }

        public long Length 
        {
            get { return _fileInfo.Length; }
        }

        public Stream Open(FileMode mode)
        {
            return _fileInfo.Open(mode);
        }

        public Stream Open(FileMode mode, FileAccess access)
        {
            return _fileInfo.Open(mode, access);
        }

        public Stream Open(FileMode mode, FileAccess access, FileShare share)
        {
            return _fileInfo.Open(mode, access, share);
        }

        public bool Exists
        {
            get
            {
                return _fileInfo.Exists;
            }
        }

        public void Refresh()
        {
            _fileInfo.Refresh();
        }

        public Stream Create()
        {
            return System.IO.File.Create(FullName);
        }

        public Stream Create(int bufferSize)
        {
            return System.IO.File.Create(FullName);
        }

        public Stream Create(int bufferSize, FileOptions options)
        {
            return System.IO.File.Create(FullName);
        }

        public void Encrypt()
        {
            _fileInfo.Encrypt();
        }

        public void Decrypt()
        {
            _fileInfo.Decrypt();
        }
    }
}
