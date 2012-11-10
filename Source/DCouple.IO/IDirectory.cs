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

using System.Collections.Generic;

namespace DCouple.IO
{
    public interface IDirectory : IFileSystemEntry
    {
        IEnumerable<IFile> Files { get; }
        IEnumerable<IDirectory> Directories  { get; }
        bool IsRoot { get; }
        void CopyTo(IDirectory directory, bool recursive, bool overwrite);
        IDirectory CreateDirectory(string name);
        void Delete(bool recursive = false);
        IEnumerable<IFile> FindFiles(string searchPattern, bool recursive = false);
        IEnumerable<IDirectory> FindDirectories(string searchPattern, bool recursive = false);
        void Create();
    }
}
