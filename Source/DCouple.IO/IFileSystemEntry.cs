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

namespace DCouple.IO
{
    public interface IFileSystemEntry
    {
        /// <summary>
        /// The parent <see cref="IDirectory"/> of this instance
        /// </summary>
        IDirectory Parent { get; }

        /// <summary>
        /// Name of entry, e.g. file.txt
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Full path including name of entry
        /// </summary>
        string FullName { get; }

		DateTime CreationTime { get; set; }
        DateTime CreationTimeUtc { get; set; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }

        FileAttributes Attributes{get;set;}

        /// <summary>
        /// The directory at the root of this directory tree
        /// </summary>
        IDirectory Root { get; }        bool Exists{ get; }

        /// <summary>
        /// Refresh this instance.
        /// </summary>
        void Refresh();
    }
}
