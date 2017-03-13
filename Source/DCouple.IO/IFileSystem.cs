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

namespace DCouple.IO
{
    /// <summary>
    /// Represents a file system, such as c:, d: or \\FileServer
    /// In future may be extended to include other volume types such as FTP, WebDAV, Zip archives etc
    /// </summary>
    public interface IFileSystem 
    {
        /// <summary>
        /// True if directory exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool DirectoryExists(string path);

        /// <summary>
        /// True if file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool FileExists(string path);

        /// <summary>
        /// Returns an instance of <see cref="IFile"/> at the given path if it exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IFile GetFile(string path);

        /// <summary>
        /// Returns an instance of <see cref="IDirectory"/> at the given path if it exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IDirectory GetDirectory(string path);

        /// <summary>
        /// Gets the current working directory of the application.
        /// </summary>
        /// <value>
        /// The current working directory of the application.
        /// </value>
        IDirectory CurrentDirectory{get;}

        string[] GetFiles(string path, string searchPattern, System.IO.SearchOption options);

        void WriteAllText(string path, string text);

        string[] LogicalDrives{get;}

    }
}
