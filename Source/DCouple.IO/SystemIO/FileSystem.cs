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

namespace DCouple.IO.SystemIO
{
    public class FileSystem : IFileSystem
    {
        /// <summary>
        /// True if directory exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool DirectoryExists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        /// <summary>
        /// True if file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        /// <summary>
        /// Returns an instance of <see cref="IFile"/> at the given path if it exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IFile GetFile(string path)
        {
            return new File(path);
        }

        /// <summary>
        /// Returns an instance of <see cref="IDirectory"/> at the given path if it exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IDirectory GetDirectory(string path)
        {
            return new Directory(path);
        }

        public IDirectory CurrentDirectory
        {
            get
            {
                return new Directory(System.IO.Directory.GetCurrentDirectory());
            }
        }

        public string[] LogicalDrives
        {
            get
            {
                return System.IO.Directory.GetLogicalDrives();
            }
        }
    }
}

